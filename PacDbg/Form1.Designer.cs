namespace PacDbg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonGo = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpenPacFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenSystemPac = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveToDisk = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textBoxURL = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textEditor1 = new Storm.TextEditor.TextEditor();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Proxy = new System.Windows.Forms.Label();
            this.textBoxProxy = new System.Windows.Forms.TextBox();
            this.textBoxPacFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(0, 0);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 16;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenPacFile,
            this.toolStripButtonOpenSystemPac,
            this.toolStripButtonSaveToDisk,
            this.toolStripButtonRun});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 86);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButtonOpenPacFile
            // 
            this.toolStripButtonOpenPacFile.Image = global::PacDbg.Properties.Resources.openfile;
            this.toolStripButtonOpenPacFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpenPacFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenPacFile.Name = "toolStripButtonOpenPacFile";
            this.toolStripButtonOpenPacFile.Size = new System.Drawing.Size(87, 83);
            this.toolStripButtonOpenPacFile.Text = "Open PAC File";
            this.toolStripButtonOpenPacFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonOpenPacFile.Click += new System.EventHandler(this.toolStripButtonOpenPacFile_Click);
            // 
            // toolStripButtonOpenSystemPac
            // 
            this.toolStripButtonOpenSystemPac.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpenSystemPac.Image")));
            this.toolStripButtonOpenSystemPac.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpenSystemPac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenSystemPac.Name = "toolStripButtonOpenSystemPac";
            this.toolStripButtonOpenSystemPac.Size = new System.Drawing.Size(107, 83);
            this.toolStripButtonOpenSystemPac.Text = "Open System PAC";
            this.toolStripButtonOpenSystemPac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonOpenSystemPac.Click += new System.EventHandler(this.toolStripButtonOpenSystemPac_Click);
            // 
            // toolStripButtonSaveToDisk
            // 
            this.toolStripButtonSaveToDisk.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveToDisk.Image")));
            this.toolStripButtonSaveToDisk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSaveToDisk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveToDisk.Name = "toolStripButtonSaveToDisk";
            this.toolStripButtonSaveToDisk.Size = new System.Drawing.Size(77, 83);
            this.toolStripButtonSaveToDisk.Text = "Save To Disk";
            this.toolStripButtonSaveToDisk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSaveToDisk.Click += new System.EventHandler(this.toolStripButtonSaveToDisk_Click);
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.Image = global::PacDbg.Properties.Resources.Actions_arrow_right_icon;
            this.toolStripButtonRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(68, 83);
            this.toolStripButtonRun.Text = "Run";
            this.toolStripButtonRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonRun.Click += new System.EventHandler(this.toolStripButtonRun_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.textBoxURL});
            this.toolStrip2.Location = new System.Drawing.Point(0, 86);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(747, 25);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "Test URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.AutoSize = false;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(600, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 111);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textEditor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.Proxy);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxProxy);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxPacFile);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(747, 532);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 19;
            // 
            // textEditor1
            // 
            this.textEditor1.ActiveView = Storm.TextEditor.Editor.ActiveView.BottomRight;
            this.textEditor1.AutomaticLanguageDetection = false;
            this.textEditor1.BracketBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(224)))), ((int)(((byte)(204)))));
            this.textEditor1.BracketBold = false;
            this.textEditor1.BracketBorderColor = System.Drawing.Color.Transparent;
            this.textEditor1.BracketItalic = false;
            this.textEditor1.BracketStrikethrough = false;
            this.textEditor1.BracketUnderline = false;
            this.textEditor1.BreakpointBackColor = System.Drawing.Color.DarkRed;
            this.textEditor1.BreakpointForeColor = System.Drawing.Color.White;
            this.textEditor1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textEditor1.CopyAsRTF = true;
            this.textEditor1.CurrentLanguage = Storm.TextEditor.Languages.XmlLanguage.JavaScript;
            this.textEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor1.EOLMarkerColor = System.Drawing.Color.ForestGreen;
            this.textEditor1.ExpansionBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.textEditor1.ExpansionSymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.textEditor1.FileName = "";
            this.textEditor1.FontName = "Consolas";
            this.textEditor1.GutterMarginColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textEditor1.GutterMarginWidth = 15;
            this.textEditor1.HighlightActiveLine = false;
            this.textEditor1.HighlightedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(236)))), ((int)(((byte)(242)))));
            this.textEditor1.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(235)))), ((int)(((byte)(241)))));
            this.textEditor1.InactiveSelectionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.textEditor1.KeepTabs = false;
            this.textEditor1.LineNumberBackColor = System.Drawing.SystemColors.Window;
            this.textEditor1.LineNumberBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.textEditor1.LineNumberForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(145)))), ((int)(((byte)(175)))));
            this.textEditor1.Location = new System.Drawing.Point(0, 0);
            this.textEditor1.LockCursorUpdate = false;
            this.textEditor1.Name = "textEditor1";
            this.textEditor1.ParseOnPaste = false;
            this.textEditor1.RowHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.textEditor1.RowPadding = 0;
            this.textEditor1.Saved = false;
            this.textEditor1.ScopeBackColor = System.Drawing.Color.Transparent;
            this.textEditor1.ScopeIndicatorColor = System.Drawing.Color.Transparent;
            this.textEditor1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(214)))), ((int)(((byte)(255)))));
            this.textEditor1.SelectionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.textEditor1.ShowEOLMarker = false;
            this.textEditor1.ShowGutterMargin = true;
            this.textEditor1.ShowLineNumbers = true;
            this.textEditor1.ShowScopeIndicator = true;
            this.textEditor1.ShowWhitespace = false;
            this.textEditor1.Size = new System.Drawing.Size(747, 266);
            this.textEditor1.SmoothScroll = false;
            this.textEditor1.SplitView = false;
            this.textEditor1.SplitViewHorizontalEdgeDistance = -4;
            this.textEditor1.SplitViewVerticalEdgeDistance = -4;
            this.textEditor1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.textEditor1.TabIndex = 19;
            this.textEditor1.TabSpaces = 4;
            this.textEditor1.UseDottedMarginBorder = false;
            this.textEditor1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 175);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(723, 75);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 22;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Detailed Execution Summary";
            this.columnHeader1.Width = 600;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(723, 56);
            this.listBox1.TabIndex = 19;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Execution Summary - Click to Go To Line of Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Proxy
            // 
            this.Proxy.AutoSize = true;
            this.Proxy.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proxy.Location = new System.Drawing.Point(12, 108);
            this.Proxy.Name = "Proxy";
            this.Proxy.Size = new System.Drawing.Size(69, 13);
            this.Proxy.TabIndex = 17;
            this.Proxy.Text = "Proxy Result";
            this.Proxy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxProxy
            // 
            this.textBoxProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProxy.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProxy.Location = new System.Drawing.Point(12, 124);
            this.textBoxProxy.Name = "textBoxProxy";
            this.textBoxProxy.ReadOnly = true;
            this.textBoxProxy.Size = new System.Drawing.Size(723, 36);
            this.textBoxProxy.TabIndex = 16;
            // 
            // textBoxPacFile
            // 
            this.textBoxPacFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPacFile.Location = new System.Drawing.Point(87, 7);
            this.textBoxPacFile.Name = "textBoxPacFile";
            this.textBoxPacFile.ReadOnly = true;
            this.textBoxPacFile.Size = new System.Drawing.Size(648, 20);
            this.textBoxPacFile.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pac File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 643);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonGo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PacDbg";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenPacFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenSystemPac;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveToDisk;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox textBoxURL;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Storm.TextEditor.TextEditor textEditor1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Proxy;
        private System.Windows.Forms.TextBox textBoxProxy;
        private System.Windows.Forms.TextBox textBoxPacFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

