using Microsoft.Win32;
using System.Diagnostics;

namespace LVAgent
{
    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetStartup(true);
            //InstallAndRun();

            LVAgentSystem agent = new LVAgentSystem();
            await agent.Start();
        }
        private void SetStartup(bool enabled)
        {
            using RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true)!;

            if (enabled)
                key.SetValue("LVController", $"\"{Application.ExecutablePath}\"");
            else
                key.DeleteValue("LVController", false);
        }
        //private void InstallAndRun()
        //{
        //    string source = Application.ExecutablePath;
        //    string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LVController");
        //    string target = Path.Combine(folder, "LVController.exe");

        //    if (Path.GetFullPath(source).Equals(Path.GetFullPath(target), StringComparison.OrdinalIgnoreCase))
        //        return;

        //    Directory.CreateDirectory(folder);
        //    File.Copy(source, target, true);

        //    Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
        //    Application.Exit();
        //}
    }
}
