using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Management;


namespace VS2010Commons
{
    public class DiskUtils
    {
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        public static string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += ":\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            return Convert.ToString(serNum);
        }

        public static string GetVolumeLabel(string strDriveLetter)
        {
            DriveInfo di = new DriveInfo(strDriveLetter);

            return di.VolumeLabel;
        }

        public static string DriveSN(string DriveLetter)
        {
            ManagementObject disk = new ManagementObject(String.Format("Win32_Logicaldisk='{0}'", DriveLetter));
            string VolumeName = disk.Properties["VolumeName"].Value.ToString();
            string SerialNumber = disk.Properties["VolumeSerialnumber"].Value.ToString();
            return SerialNumber.Insert(4, "-");
        }

        public static string DriveSNFromPath(string path)
        {
            string driveLetter = Path.GetPathRoot(path);
            driveLetter = driveLetter.Substring(0, 2);
            ManagementObject disk = new ManagementObject(String.Format("Win32_Logicaldisk='{0}'", driveLetter));
            string VolumeName = disk.Properties["VolumeName"].Value.ToString();
            string SerialNumber = disk.Properties["VolumeSerialnumber"].Value.ToString();
            return SerialNumber.Insert(4, "-");
        }


    }
}
