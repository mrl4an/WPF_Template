using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Template.Services.Lifecycle
{
    public interface ILifecycleService
    {
        void OnWindowClosing(object? sender, CancelEventArgs e);
        void Shutdown();
    }
}
