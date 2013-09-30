using Jint;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace PacDbg
{
   
    public partial class Form1 : Form
    {
        /// <summary>
        /// Runs background task to update proxy
        /// </summary>
        BackgroundWorker worker = new BackgroundWorker();

        /// <summary>
        /// Stores Execution History in a List
        /// </summary>
        List<string> executionHistory = new List<string>();

        /// <summary>
        /// Proxy Functions
        /// </summary>
        /// <param name="host"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        delegate bool localHostOrDomainIsDelegate(string host, string pattern);
        delegate string myIpAddressDelegate();
        delegate bool isResolvableDelegate(string host);
        delegate bool dateRangeDelegate(string start, string end);
        delegate bool weekdayRangeDelegate(string start, string end);
        delegate bool timeRangeDelegate(int start, int end);
        delegate bool isPlainHostNameDelegate(string host);
        delegate bool dnsDomainIsDelegate(string host, string domain);
        delegate string dnsResolveDelegate(string host);
        delegate void alertDelegate(string message);
        delegate bool IsInNetDelegate(string host, string pattern, string mask);
        delegate int dnsDomainLevelsDelegate(string host);
        delegate bool shExpMatchDelegate(string str, string shexp);

        string lastStatement = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private int SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            int matches = 0;
            // precomputing this shaves some seconds from the loop execution
            int maxloop = bytes.Length - pattern.Length;
            for (int i = 0; i < maxloop; i++)
            {
                if (pattern[0] == bytes[i])
                {
                    bool ismatch = true;
                    for (int j = 1; j < pattern.Length; j++)
                    {
                        if (bytes[i + j] != pattern[j])
                        {
                            ismatch = false;
                            break;
                        }
                    }
                    if (ismatch)
                    {
                        matches = i;
                        i += pattern.Length - 1;
                    }
                }
            }
            return matches;
        }

        private void GetSystemProxy()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");

            if (key!=null)
            {
                textBoxPacFile.Text = key.GetValue("AutoConfigURL", "").ToString();

                byte[] bytes =(byte[])key.OpenSubKey("Connections").GetValue("DefaultConnectionSettings", null);

                if (bytes!=null)
                {
                    byte[] searchPattern=new byte[4]{ 26,0,0,0 };
                    int i = SearchBytePattern(searchPattern, bytes) + 4;

                    string wpad = System.Text.Encoding.ASCII.GetString(bytes, i, bytes.Length - i);
                    wpad = wpad.Substring(0, wpad.IndexOf('\0'));

                    if (string.IsNullOrEmpty(textBoxPacFile.Text))
                    {
                        if (!string.IsNullOrEmpty(wpad))
                        {
                            textBoxPacFile.Text = wpad;
                        }
                    }
                    else
                    {

                        if (wpad.Length > 4)
                        {
                            if (wpad != textBoxPacFile.Text)
                            {
                                MessageBox.Show(string.Format("WARNING: AutoDetect PAC file is '{0}' and configured proxy PAC is '{1}'",
                                    wpad,
                                    textBoxPacFile.Text),
                                    "PacDbg",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }

            }

            LoadProxy();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            textBoxURL.Text = "http://www.google.com.au/";

            GetSystemProxy();

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(delegate
            {
                toolStripButtonRun.Enabled = true;
            }));
        }

        /// <summary>
        /// Permission required, otherwise Jint DLL throws exeption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        void jint_Step(object sender, Jint.Debugger.DebugInformation e)
        {
            if (!e.CurrentStatement.Source.Code.StartsWith("FindProxyForURL"))
            {
                listBox1.Invoke(new Action(delegate
                {
                    listBox1.Items.Add(string.Format("{0}: {1}\n", e.CurrentStatement.Source, e.CurrentStatement.Source.Code));
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    string source = e.CurrentStatement.Source.ToString();
                    if (source.Contains(" "))
                    {
                        string lineNumber = source.Split(' ')[1];
                        int line;
                        if (Int32.TryParse(lineNumber, out line))
                        {
                            textEditor1.HighlightActiveLine = true;
                            textEditor1.GotoLine(line - 1);
                        }
                    }

                }));
            }
            
        }

        /// <summary>
        /// Permission required or Jint throws exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string script=textEditor1.Text;

            IsInNetDelegate IsInNet = PacExtensions.IsInNetAction;
            localHostOrDomainIsDelegate localHostOrDomainIs = PacExtensions.localHostOrDomainIs;
            myIpAddressDelegate myIpAddress = PacExtensions.myIpAddress;
            isResolvableDelegate isResolvable = PacExtensions.isResolvable;
            dateRangeDelegate dateRange = PacExtensions.dateRange;
            weekdayRangeDelegate weekdayRange = PacExtensions.weekdayRange;
            timeRangeDelegate timeRange = PacExtensions.timeRange;
            isPlainHostNameDelegate isPlainHostName = PacExtensions.isPlainHostName;
            dnsDomainIsDelegate dnsDomainIs = PacExtensions.dnsDomainIs;
            dnsResolveDelegate dnsResolve = PacExtensions.dnsResolve;
            alertDelegate alert = PacExtensions.alert;
            dnsDomainLevelsDelegate dnsDomainLevels = PacExtensions.dnsDomainLevels;
            shExpMatchDelegate shExpMatch = PacExtensions.shExpMatch;

            JintEngine jint = new JintEngine()
                .SetDebugMode(true)
                .SetFunction("isInNet", IsInNet)
                .SetFunction("localHostOrDomainIs", localHostOrDomainIs)
                .SetFunction("myIpAddress", myIpAddress)
                .SetFunction("isResolvable", isResolvable)
                .SetFunction("dateRange", dateRange)
                .SetFunction("weekdayRange", weekdayRange)
                .SetFunction("timeRange", timeRange)
                .SetFunction("isPlainHostName", isPlainHostName)
                .SetFunction("dnsDomainIs", dnsDomainIs)
                .SetFunction("dnsResolve", dnsResolve)
                .SetFunction("alert", alert)
                .SetFunction("dnsDomainLevels", dnsDomainLevels)
                .SetFunction("shExpMatch", shExpMatch);

            try
            {
                jint.Step += jint_Step;
                textEditor1.Text = script;

                var result = jint.Run(script);

                executionHistory.Clear();
                listBox1.Invoke(new Action(delegate
                {
                    listBox1.Items.Clear();
                }));

                Uri uri;

                if (!textBoxURL.Text.Contains("://"))
                {
                    this.Invoke(new Action(delegate
                        {
                            textBoxURL.Text = "http://" + textBoxURL.Text;
                        }));
                }
                if (!Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uri))
                {
                    listView1.Invoke(new Action(delegate
                        {
                            listView1.Items.Add(string.Format("'{0}' is not a valid URL", textBoxURL.Text), 2);
                        }));
                }
                else
                {
                    PacExtensions.CounterReset();
                    result = jint.Run(string.Format("FindProxyForURL(\"{0}\",\"{1}\")", uri.ToString(), uri.Host));

                    Trace.WriteLine(result);
                    textBoxProxy.Invoke(new Action(delegate
                    {
                        listView1.Items.Add(string.Format("IsInNet Count: {0} Total Duration: {1} ms", PacExtensions.IsInNetCount, PacExtensions.IsInNetDuration.Milliseconds));
                        listView1.Items.Add(string.Format("DnsDomainIs Count: {0} Total Duration: {1} ms", PacExtensions.DnsDomainIsCount, PacExtensions.DnsDomainIsDuration.Milliseconds));

                        textBoxProxy.Text = result.ToString();
                        foreach (string s in PacExtensions.EvaluationHistory)
                        {
                            listView1.Items.Add(s, 0);
                        }
                    }));
                }



            }

            catch (Jint.Native.JsException ex)
            {
                listBox1.Invoke(new Action(delegate
                {
                    string msg = ex.Message.Replace("An unexpected error occurred while parsing the script. Jint.JintException: ", "");
                    listView1.Items.Add(msg, 2);
                }));


            }
            catch (System.NullReferenceException)
            {
                listBox1.Invoke(new Action(delegate
                {
                    string msg = "Null reference. Probably variable/function not defined, remember functions and variables are case sensitive.";
                    listView1.Items.Add(msg, 2);
                }));
            }
            catch (JintException ex)
            {
                listBox1.Invoke(new Action(delegate
                {
                    int i = ex.InnerException.ToString().IndexOf(":");

                    string msg = ex.InnerException.ToString();

                    if (msg.Contains("line"))
                    {
                        int x = msg.IndexOf("line");
                        int y = msg.IndexOf(":", x);
                        if (y > 0)
                        {
                            string lineNumber = msg.Substring(x + 5, y - x - 5);
                            int line;
                            if (Int32.TryParse(lineNumber, out line))
                            {
                                textEditor1.HighlightActiveLine = true;
                                textEditor1.GotoLine(line - 1);
                            }
                        }
                    }

                    if (i > 0)
                    {
                       msg= msg.Substring(i + 1);
                    }
                    msg = msg.Substring(0, msg.IndexOf("  at Jint."));

                    if (msg.Contains("Object reference not set to an instance of an object."))
                    {
                        msg = "Variable/Function not defined. Remember variables/functions are case sensitive.";
                    }

                    //.Replace("An unexpected error occurred while parsing the script. Jint.JintException: ", "");
                    listView1.Items.Add(msg, 2);

                    if (!msg.Contains("Variable/Function not defined."))
                    {

                        listBox1.Items.Add(string.Format("Fatal Error: {0}. {1}", ex.Message, ex.InnerException));
                    }
                }));
            }
            catch (Exception ex)
            {
                listBox1.Invoke(new Action(delegate
                {
                    listBox1.Items.Add(string.Format("Fatal Error: {0}", ex.Message));
                }));
            }
        }

        /// <summary>
        /// Loads Proxy....
        /// </summary>
        private void LoadProxy()
        {
            string filename=textBoxPacFile.Text;

            try
            {
                if (textBoxPacFile.Text.Contains("://"))
                {

                    using (WebClient Client = new WebClient())
                    {
                        filename = Path.GetTempFileName();
                        Client.DownloadFile(textBoxPacFile.Text,filename);
                        using (StreamReader sr = new StreamReader(filename))
                        {
                            textEditor1.Text = sr.ReadToEnd();
                        }
                    }
                }

                listView1.Items.Clear();
                 
                if (textBoxPacFile.Text.StartsWith("file:"))
                {
                    listView1.Items.Add(
                        "Proxy PAC is set via file:// not all applications support this method, please use http location", 1);
                }

                using (StreamReader reader = href.Utils.EncodingTools.OpenTextFile(filename))
                {
                    if (reader.CurrentEncoding.GetType() != typeof(System.Text.ASCIIEncoding))
                    {
                        listView1.Items.Add(string.Format("PAC file is {0} encoded. Some applications may only support ASCII encoded PAC files", reader.CurrentEncoding.EncodingName), 1);
                    }
                    else
                    {
                        listView1.Items.Add("PAC file is ASCII encoded", 0);
                    }

                    textEditor1.Text = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to open '{0}' Error: {1}", textBoxPacFile.Text,
                    ex.Message),
                    "PacDbg",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void textEditor1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textEditor1.Width = this.Width - textEditor1.Left - 20;
            textEditor1.Height = this.Height-textEditor1.Top - 50;
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            toolStripButtonRun.Enabled = false;
            listView1.Items.Clear();
            worker.RunWorkerAsync();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string source = listBox1.SelectedItem.ToString();
                if (source.Contains(" "))
                {
                    string lineNumber = source.Split(' ')[1];
                    int line;
                    if (Int32.TryParse(lineNumber, out line))
                    {
                        textEditor1.HighlightActiveLine = true;
                        textEditor1.GotoLine(line - 1);
                    }
                }
            }
        }

        private void toolStripButtonOpenSystemPac_Click(object sender, EventArgs e)
        {
            GetSystemProxy();
        }

        private void toolStripButtonOpenPacFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PAC Files (*.pac; wpad.dat)|*.pac;wpad.dat|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPacFile.Text = dialog.FileName;
                LoadProxy();
            }
        }

        private void toolStripButtonSaveToDisk_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "PAC Files (*.pac; wpad.dat)|*.pac;wpad.dat|All Files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(dialog.FileName, false, Encoding.ASCII))
                    {
                        sw.Write(textEditor1.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to save. Error '{0}'", 
                    ex.Message),
                    "PacDbg",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
    }
}
