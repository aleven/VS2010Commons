using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace VS2010Commons
{
    public class PCUtils
    {
        public static string CurrentUser = WindowsIdentity.GetCurrent().Name;
        public static string MachineName = Environment.MachineName;

        public static string OSVersion = Environment.OSVersion.ToString();

        //public static string Name2 = System.Net.Dns.GetHostName();
        //public static string Name3 = System.Windows.Forms.SystemInformation.ComputerName;
        //public static string Name4 = System.Environment.GetEnvironmentVariable("COMPUTERNAME");

    }
}
