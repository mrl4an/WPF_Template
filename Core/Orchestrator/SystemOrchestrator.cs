using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Template.Core.Orchestrator
{
    public class SystemOrchestrator : ISystemOrchestrator
    {
        private int _activeTasksCount = 0;
        public void QueueTask(Func<Task> backgroundAction)
        {
            Interlocked.Increment(ref _activeTasksCount);

            Task.Run(async () =>
            {
                try
                {
                    await backgroundAction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Orchestrator error: {ex.Message}");
                }
                finally
                {
                    Interlocked.Decrement(ref _activeTasksCount);
                }
            });
        }

        public async Task WaitForCompletionAsync(int timeoutMs = 3000)
        {
            using var cts = new CancellationTokenSource(timeoutMs);
            try
            {
                while (_activeTasksCount > 0)
                {
                    if (cts.Token.IsCancellationRequested) break;
                    await Task.Delay(50, cts.Token);
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("System orchestrator error: timeout");
            }
        }
    }
}
