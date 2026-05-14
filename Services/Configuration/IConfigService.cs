using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Template.Models;

namespace WPF_Template.Services.Configuration
{
    public interface IConfigService
    {
        AppConfig Current { get; }
        Task LoadAsync();
        Task SaveAsync();
    }
}
