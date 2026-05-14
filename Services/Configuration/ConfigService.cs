using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using WPF_Template.Models;

namespace WPF_Template.Services.Configuration
{
    public class ConfigService : IConfigService
    {
        private readonly string _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "WPF_Template", "config.json");

        public AppConfig Current { get; private set; } = new AppConfig();

        public async Task LoadAsync()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Current = new AppConfig();
                    return;
                }

                using var stream = File.OpenRead(_filePath);
                var loaded = await JsonSerializer.DeserializeAsync<AppConfig>(stream);
                Current = loaded ?? new AppConfig();
            }
            catch
            {
                Current = new AppConfig();
            }
        }

        public async Task SaveAsync()
        {
            using var cts = new System.Threading.CancellationTokenSource(1500); //cancellation token
            try
            {
                string? directory = Path.GetDirectoryName(_filePath);
                if (directory != null) Directory.CreateDirectory(directory);

                var options = new JsonSerializerOptions { WriteIndented = true };

                using var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);

                await JsonSerializer.SerializeAsync(stream, Current, options, cts.Token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("ConfigService: OS timeout");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ConfigService: Critical error: {ex.Message}");
            }
        }
    }
}
