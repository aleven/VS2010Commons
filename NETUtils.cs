using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace VS2010Commons
{
    public class NETUtils
    {
        /// <summary> 
        /// returns the mac address of the NIC with max speed. 
        /// </summary> 
        /// <returns></returns> 
        public static string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = "";
            long maxSpeed = -1;

            StringBuilder sb = new StringBuilder();
            HashSet<string> macs = new HashSet<string>();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // log.Debug("Found MAC Address: " + nic.GetPhysicalAddress().ToString() + " Type: " + nic.NetworkInterfaceType);
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed && !String.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    // log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }

                if (!String.IsNullOrEmpty(tempMac) && tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    macs.Add(tempMac);
                }
            }

            foreach (String s in macs)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.Append(s);
            }

            return sb.ToString();
        }

    }
}
