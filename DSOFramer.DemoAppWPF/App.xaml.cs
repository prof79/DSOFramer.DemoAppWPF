// App.xaml.cs

namespace DSOFramer.DemoAppWPF
{
    using DSOFramer.DemoApps;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Set process DPI-awareness for Office-embedding.
            var hrResult = Interop.SetProcessDpiAwareness(
                Interop.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE
            );

            //System.Console.WriteLine($"Setting DPI awareness: {hrResult}");
        }
    }
}
