using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PacDbg
{
    static class PacExtensions
    {
        public static int IsInNetCount;
        public static TimeSpan IsInNetDuration;
        public static int DnsDomainIsCount;
        public static TimeSpan DnsDomainIsDuration;
        public static int IsResolvableCount;
        public static TimeSpan IsResolvableDuration;
        public static int shExpMatchCount;
        public static TimeSpan shExpMatchDuration;
        public static int DnsResolve;
        public static TimeSpan DnsResolveDuration;
        public static List<string> EvaluationHistory;
        public static void CounterReset()
        {
            IsInNetCount=0;
            IsInNetDuration = new TimeSpan(0);

            DnsDomainIsCount = 0;
            DnsDomainIsDuration = new TimeSpan(0);

            IsResolvableCount = 0;
            IsResolvableDuration = new TimeSpan(0);

            shExpMatchCount = 0;
            shExpMatchDuration = new TimeSpan(0);

            DnsResolve = 0;
            DnsResolveDuration = new TimeSpan(0);

            EvaluationHistory = new List<string>();
        }
        /// <summary>
        /// Returns true if host has exact match for pattern.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool localHostOrDomainIs(string host,string pattern)
        {
            if (pattern.Contains(host))
            {
                EvaluationHistory.Add(string.Format("localHostOrDomainIs(\"{0}\",\"{1}\")=true",host,pattern));
                return true;
            }
            else
            {
                EvaluationHistory.Add(string.Format("localHostOrDomainIs(\"{0}\",\"{1}\")=false", host, pattern));
                return false;
            }
        }

        public static bool shExpMatch(string str, string shexp)
        {
           string pattern= "^" + Regex.Escape(shexp).
                       Replace(@"\*", ".*").
                       Replace(@"\?", ".") + "$";

           Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
           if (regex.IsMatch(str))
           {
               EvaluationHistory.Add(string.Format("shExpMatch(\"{0}\",\"{1}\")=true", str, shexp));
               return true;
           }
           else
           {
               EvaluationHistory.Add(string.Format("shExpMatch(\"{0}\",\"{1}\")=false", str, shexp));
               return false;
           }

        }

        /// <summary>
        /// Returns true if name can be resolved.
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool isResolvable(string host)
        {
            IPAddress[] ips = Dns.GetHostAddresses(host);
            if (ips.Length>0)
            {
                EvaluationHistory.Add(string.Format("isResolvable(\"{0}\")=true",host));
                return true;
            }
            else
            {
                EvaluationHistory.Add(string.Format("isResolvable(\"{0}\")=false", host));
                return false;
            }
        }

        /// <summary>
        /// Returns true if the current date is between specified month
        /// i.e. dateRange("JAN","MAR") will return true between January and March.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool dateRange(string start, string end)
        {
            int month = DateTime.Now.Month;
            DateTime month_start;
            DateTime month_end;
            if (DateTime.TryParse(string.Format("{0} 1, 1900", start),out month_start))
            {
                if (DateTime.TryParse(string.Format("{0} 1, 1900", end), out month_end))
                {
                    if (month >= month_start.Month && month <= month_end.Month)
                    {
                        EvaluationHistory.Add(string.Format("dateRange(\"{0}\",\"{1}\")=true", start,end));
                        return true;
                    }
                }
            }

            EvaluationHistory.Add(string.Format("dateRange(\"{0}\",\"{1}\")=false", start, end));
            return false;
        }

        public static bool timeRange(int start, int end)
        {
            int hour = DateTime.Now.Hour;
            if (hour >= start && hour <= end)
            {
                EvaluationHistory.Add(string.Format("timeRange(\"{0}\",\"{1}\")=true", start, end));
                return true;
            }

            EvaluationHistory.Add(string.Format("timeRange(\"{0}\",\"{1}\")=false", start, end));
            return false;
        }

        /// <summary>
        /// Check
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool weekdayRange(string start, string end)
        {
            DayOfWeek today = DateTime.Now.DayOfWeek;
            DayOfWeek startday = DayOfWeek.Monday;
            DayOfWeek endday = DayOfWeek.Monday;

            switch (start)
            {
                case "MON":
                    startday  = DayOfWeek.Monday;
                    break;
                case "TUE":
                    startday = DayOfWeek.Tuesday;
                    break;
                case "WED":
                    startday = DayOfWeek.Wednesday;
                    break;
                case "THU":
                    startday = DayOfWeek.Thursday;
                    break;
                case "FRI":
                    startday = DayOfWeek.Friday;
                    break;
                case "SAT":
                    startday = DayOfWeek.Saturday;
                    break;
                case "SUN":
                    startday = DayOfWeek.Sunday;
                    break;
            }

            switch (end)
            {
                case "MON":
                    endday = DayOfWeek.Monday;
                    break;
                case "TUE":
                    endday = DayOfWeek.Tuesday;
                    break;
                case "WED":
                    endday = DayOfWeek.Wednesday;
                    break;
                case "THU":
                    endday = DayOfWeek.Thursday;
                    break;
                case "FRI":
                    endday = DayOfWeek.Friday;
                    break;
                case "SAT":
                    endday = DayOfWeek.Saturday;
                    break;
                case "SUN":
                    endday = DayOfWeek.Sunday;
                    break;
            }

            if (today >= startday && today <= endday)
            {
                EvaluationHistory.Add(string.Format("weekdayRange(\"{0}\",\"{1}\")=true", startday, endday));
                return true;
            }
            else
            {
                EvaluationHistory.Add(string.Format("weekdayRange(\"{0}\",\"{1}\")=false", startday, endday));
                return false;
            }
        }

       
        /// <summary>
        /// Count number of . in domain.
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static int dnsDomainLevels(string host)
        {
            var count = host.Count(x => x == '.');
            EvaluationHistory.Add(string.Format("dnsDomainLevels(\"{0}\")={1}", host,count));
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool isPlainHostName(string host)
        {
           
            if (host.Contains("."))
            {
                EvaluationHistory.Add(string.Format("isPlainHostName(\"{0}\")=false", host));
                return false;
            }
            else
            {
                EvaluationHistory.Add(string.Format("isPlainHostName(\"{0}\")=true", host));
                return true;
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
       [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool dnsDomainIs(string host, string domain)
        {
            DnsDomainIsCount++;
            DateTime StartTime = DateTime.Now;
            TimeSpan totalTime;

            if (host.EndsWith(domain,StringComparison.InvariantCultureIgnoreCase))
            {
                totalTime = DateTime.Now - StartTime;
                DnsDomainIsDuration += totalTime;
                EvaluationHistory.Add(string.Format("dnsDomainIs(\"{0}\",\"{1}\")=true", host,domain));
                return true;
            }
            else
            {
                totalTime = DateTime.Now - StartTime;
                DnsDomainIsDuration += totalTime;
                EvaluationHistory.Add(string.Format("dnsDomainIs(\"{0}\",\"{1}\")=false", host, domain));
                return false;
            }
        }

        /// <summary>
        /// Resolves hostname to IP.
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static string dnsResolve(string host)
        {
            IPAddress[] ips = Dns.GetHostAddresses(host);

            string ip;
            if (ips.Length > 0)
            {
                ip = ips[0].ToString();
            }
            else
            {
                ip = host;
            }
            EvaluationHistory.Add(string.Format("dnsResolve(\"{0}\")={1}", host, ip));
               
            return ip;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="pattern"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        /// 
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static bool IsInNetAction(string host, string pattern, string mask)
        {
            IsInNetCount++;
            DateTime StartTime = DateTime.Now;
            TimeSpan totalTime;

            IPAddress[] ips = Dns.GetHostAddresses(host);

            string ip = string.Empty;
            if (ips.Length > 0)
            {

                foreach (IPAddress _ip in ips)
                {
                    if (_ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ip = _ip.ToString();
                        break;
                    }
                }
            }
            else
            {
                ip = host;
            }

            IPAddress host_address;
            
            if (IPAddress.TryParse(ip, out host_address))
            {
                IPAddress pattern_address;
                if (IPAddress.TryParse(pattern, out pattern_address))
                {
                    IPAddress mask_address;
                    if (IPAddress.TryParse(mask,out mask_address))
                    {
                        if (IPAddressExtensions.IsInSameSubnet(
                            host_address,
                            pattern_address,
                            mask_address))
                        {
                            totalTime = DateTime.Now - StartTime;
                            IsInNetDuration += totalTime;
                            EvaluationHistory.Add(string.Format("isInNet(\"{0}\",\"{1}\",\"{2}\")=true", host, pattern,mask));
                            return true;
                        }
                        else
                        {
                            totalTime = DateTime.Now - StartTime;
                            IsInNetDuration += totalTime;
                            EvaluationHistory.Add(string.Format("isInNet(\"{0}\",\"{1}\",\"{2}\")=false", host, pattern, mask));
                            return false;
                        }
                    }
                    else
                    {
                        totalTime = DateTime.Now - StartTime;
                        IsInNetDuration += totalTime;
                        EvaluationHistory.Add(string.Format("isInNet(\"{0}\",\"{1}\",\"{2}\")=false", host, pattern, mask));
                        return false;
                    }
                }
                else
                {
                    totalTime = DateTime.Now - StartTime;
                    IsInNetDuration += totalTime;
                    EvaluationHistory.Add(string.Format("isInNet(\"{0}\",\"{1}\",\"{2}\")=false", host, pattern, mask));
                    return false;
                }
            }
            else
            {
                totalTime = DateTime.Now - StartTime;
                IsInNetDuration += totalTime;
                EvaluationHistory.Add(string.Format("isInNet(\"{0}\",\"{1}\",\"{2}\")=false", host, pattern, mask));
                return false;
            }
        }
        
        /// <summary>
        /// Retrieves the first IP address.
        /// Should replicate CJSProxy::myIpAddress in jsproxy.dll
        /// </summary>
        /// <returns>Retrieves first IP address</returns>
        /// 
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static string myIpAddress()
        {
            IPAddress[] ips = Dns.GetHostAddresses("");
            if (ips.Length > 0)
            {
                foreach (IPAddress ip in ips)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        EvaluationHistory.Add(string.Format("myIpAddress={0}", ip.ToString()));
                        return ip.ToString();
                    }

                }
            }
            else
            {
                EvaluationHistory.Add(string.Format("myIpAddress=127.0.0.1", ips[0].ToString()));
                return "127.0.0.1";
            }

            return "127.0.0.1";

        }

        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public static void alert(string message)
        {
            EvaluationHistory.Add(string.Format("alert(\"{0}\")", message));
            MessageBox.Show(message);
        }
        
    }
}
