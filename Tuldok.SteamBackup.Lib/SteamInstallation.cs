using Gameloop.Vdf;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Gameloop.Vdf.Linq;
using System.Linq;

namespace Tuldok.SteamBackup.Lib
{
    public class SteamInstallation
    {
        private List<SteamLibrary> _steamLibraries;
        
        public List<SteamLibrary> Libraries
        {
            get
            {
                return _steamLibraries;
            }
        }

        public SteamInstallation(string steamInstallationPath)
        {
            var installationPath = steamInstallationPath;
            _steamLibraries = new List<SteamLibrary>();
            var steamFolderStr = Path.Combine(installationPath, "steamapps", "libraryfolders.vdf");

            dynamic steamFolder = VdfConvert.Deserialize(File.ReadAllText(steamFolderStr));

            foreach (dynamic item in steamFolder.Value)
            {
                int converted;
                if (int.TryParse(item.Key, out converted))
                {
                    var libraryPath = (item.Value["path"]).ToString();
                    _steamLibraries.Add(new SteamLibrary(libraryPath));
                }
            }

            //var appId = next["appid"].Value<string>();
            //var name = next["name"].Value<string>();
            //var installPath = next["installpath"].Value<string>();

            //var game = new SteamGame(name, installPath, appId);
        }
    }
}
