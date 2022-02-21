﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using static Hi3Helper.Logger;
using static Hi3Helper.InvokeProp;
using static Hi3Helper.Shared.Region.LauncherConfig;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CollapseLauncher.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            this.DataContext = this;

            AppVersionTextBlock.Text = $" {Assembly.GetExecutingAssembly().GetName().Version}";
        }

        public bool EnableConsole { get { return Hi3Helper.Logger.EnableConsole; } }

        private void ConsoleToggle(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggle = sender as ToggleSwitch;

            if (toggle.IsOn)
                ShowConsoleWindow();
            else
                HideConsoleWindow();

            SetAppConfigValue("EnableConsole", toggle.IsOn);
            InitLog(true, AppDataFolder);
        }
    }
}