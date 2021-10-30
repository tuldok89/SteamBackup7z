using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Gameloop.Vdf;
using Gameloop.Vdf.Linq;

namespace Tuldok.SteamBackup.Lib
{
    public class SteamLibrary
    {
        private List<SteamGame> _steamGames;
        public List<SteamGame> SteamGames
        {
            get
            {
                return _steamGames;
            }
        }

        public SteamLibrary(string libraryPath)
        {
            _steamGames = new List<SteamGame>();

            var acfFiles = Directory.EnumerateFiles(Path.Combine(libraryPath, "steamapps"), "*.acf");

            foreach(var file in acfFiles)
            {
                dynamic appManifest = VdfConvert.Deserialize(File.ReadAllText(file));
                dynamic appState = appManifest.Value;

                dynamic appid = appState["appid"];
                dynamic name = appState["name"];
                dynamic installdir = Path.Combine(libraryPath, "steamapps", "common", appState["installdir"].ToString());

                _steamGames.Add(new SteamGame(name.ToString(), installdir, appid.ToString()));
            }
        }
    }
}