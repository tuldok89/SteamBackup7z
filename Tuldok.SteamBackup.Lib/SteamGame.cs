using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tuldok.SteamBackup.Lib
{
    public class SteamGame
    {
        public string Name { get; set; }
        public string InstallPath { get; set; }
        public string AppId { get; set; }
        
        public SteamGame(string name, string installPath, string appId)
        {
            Name = name;
            InstallPath = installPath;
            AppId = appId;
        }

        public IEnumerable<string> GetFiles()
        {
            var files = Directory.EnumerateFileSystemEntries(InstallPath, "*", SearchOption.AllDirectories);

            return files;
        }
    }
}
