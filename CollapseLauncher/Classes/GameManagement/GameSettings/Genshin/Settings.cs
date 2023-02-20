﻿using CollapseLauncher.GameSettings.Base;
using CollapseLauncher.GameSettings.Universal;
using CollapseLauncher.Interfaces;
using Hi3Helper.Preset;
using Microsoft.Win32;
using System.IO;
using static CollapseLauncher.GameSettings.Statics;

namespace CollapseLauncher.GameSettings.Genshin
{
    internal class GenshinSettings : ImportExportBase, IGameSettings, IGameSettingsUniversal
    {
        public CustomArgs SettingsCustomArgument { get; set; }
        public BaseScreenSettingData SettingsScreen { get; set; }
        public CollapseScreenSetting SettingsCollapseScreen { get; set; }

        public GenshinSettings(PresetConfigV2 gameConfig)
        {
            // Init Root Registry Key
            RegistryRootPath = Path.GetDirectoryName(gameConfig.ConfigRegistryLocation);
            RegistryPath = Path.Combine(RegistryRootPath, gameConfig.InternalGameNameInConfig);
            RegistryRoot = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            // If the Root Registry Key is null (not exist), then create a new one.
            if (RegistryRoot == null)
            {
                RegistryRoot = Registry.CurrentUser.CreateSubKey(RegistryPath, true, RegistryOptions.None);
            }

            // Initialize and Load Settings
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            // Load Settings
            SettingsCustomArgument = CustomArgs.Load();
        }

        public void RevertSettings() => InitializeSettings();

        public void SaveSettings()
        {
            // Save Settings
            SettingsCustomArgument.Save();
        }

        public IGameSettingsUniversal AsIGameSettingsUniversal() => this;
    }
}