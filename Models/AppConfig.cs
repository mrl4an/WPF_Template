using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Template.Models
{
    public class AppConfig
    {

        public bool IsDarkTheme { get; set; } = true;
        public string SelectedAccent { get; set; } = "purple";
        public string SelectedLanguage { get; set; } = "en";


        public double WindowWidth { get; set; } = 850;
        public double WindowHeight { get; set; } = 500;
        public double WindowTop { get; set; } = 100;
        public double WindowLeft { get; set; } = 100;
        public bool IsMaximized { get; set; } = false;
    }
}
