using System;
using Microsoft.Win32;

namespace Tuldok.SteamBackup.Lib
{
    public static class Utilities
    {
        public static string SteamInstallationPath()
        {
            if (Environment.Is64BitProcess)
            {
                return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);
            }
            else
            {
                return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", null);
            }
        }
    }
}
