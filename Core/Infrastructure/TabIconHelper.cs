using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Template.Core.Infrastructure
{
    public static class TabIconHelper
    {
        // Icon for tabs
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached(
                "Icon",
                typeof(string),
                typeof(TabIconHelper),
                new PropertyMetadata(string.Empty));

        public static string GetIcon(DependencyObject obj) => (string)obj.GetValue(IconProperty);
        public static void SetIcon(DependencyObject obj, string value) => obj.SetValue(IconProperty, value);
    }
}
