using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Template.Core;
using WPF_Template.Core.Orchestrator;
using WPF_Template.Services.Configuration;

namespace WPF_Template.ViewModel
{
    public class SettingsViewModel : ObservableObject
    {
        private readonly ISystemOrchestrator _orchestrator;
        private readonly IConfigService _configService;


        private bool _isDarkTheme = true;
        private string _selectedAccent = "purple";
        private string _selectedLanguage = "ru";

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    _configService.Current.IsDarkTheme = value;

                    string themeName = value ? "Dark" : "Light";
                    UpdateApplicationResource("/Resources/Styles/Themes/", themeName);

                    _orchestrator.QueueTask(async () => await _configService.SaveAsync());
                }
            }
        }

        public string SelectedAccent
        {
            get => _selectedAccent;
            set
            {
                if (SetProperty(ref _selectedAccent, value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _configService.Current.SelectedAccent = value;
                        string accentName = char.ToUpper(value[0]) + value.Substring(1);
                        UpdateApplicationResource("/Resources/Styles/Accents/", accentName);

                        _orchestrator.QueueTask(async () => await _configService.SaveAsync());
                    }
                }
            }
        }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (SetProperty(ref _selectedLanguage, value))
                {
                    _configService.Current.SelectedLanguage = value;
                    UpdateApplicationResource("/Resources/Languages/", $"Lang.{value}");

                    _orchestrator.QueueTask(async () => await _configService.SaveAsync());
                }
            }
        }

        public SettingsViewModel(ISystemOrchestrator orchestrator, IConfigService configService)
        {
            _orchestrator = orchestrator;
            _configService = configService;

            _isDarkTheme = _configService.Current.IsDarkTheme;
            _selectedAccent = _configService.Current.SelectedAccent;
            _selectedLanguage = _configService.Current.SelectedLanguage;

            string themeName = _isDarkTheme ? "Dark" : "Light";
            UpdateApplicationResource("/Resources/Styles/Themes/", themeName);

            string accentName = char.ToUpper(_selectedAccent[0]) + _selectedAccent.Substring(1);
            UpdateApplicationResource("/Resources/Styles/Accents/", accentName);

            UpdateApplicationResource("/Resources/Languages/", $"Lang.{_selectedLanguage}");
        }


        private void UpdateApplicationResource(string folderPath, string newFileName)
        {
            string newUriPath = $"{folderPath}{newFileName}.xaml";
            var newDict = new ResourceDictionary { Source = new Uri(newUriPath, UriKind.Relative) };

            ReplaceInCollection(Application.Current.Resources.MergedDictionaries, folderPath, newDict);

            foreach (Window window in Application.Current.Windows)
            {
                ReplaceInCollection(window.Resources.MergedDictionaries, folderPath, newDict);
            }
        }

        private void ReplaceInCollection(System.Collections.ObjectModel.Collection<ResourceDictionary> collection, string folderPath, ResourceDictionary newDict)
        {
            var oldDict = collection.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains(folderPath));

            if (oldDict != null)
            {
                int index = collection.IndexOf(oldDict);
                collection[index] = newDict;
            }
            else
            {
                collection.Add(newDict);
            }
        }
    }
}