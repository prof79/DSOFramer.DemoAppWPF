// MainWindow.xaml.cs

namespace DSOFramer.DemoAppWPF
{
    using System.Windows;
    using System.Windows.Forms.Integration;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DsoOffice dsoOffice = null;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void LoadDSO()
        {
            WindowsFormsHost host = new WindowsFormsHost();

            var panel = new System.Windows.Forms.Panel();

            dsoOffice = new DsoOffice();

            dsoOffice.Dock = System.Windows.Forms.DockStyle.Fill;

            panel.Controls.Add(dsoOffice);

            host.Child = panel;

            gridOffice.Children.Add(host);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDSO();
        }

        private void OpenDocument_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            
            ofd.Filter =
                "Microsoft Office Files|*.doc?;*.xls?;*.ppt?;*.pps?|Microsoft Word Files|*.doc?|Microsoft Excel Files|*.xls?|Microsoft PowerPoint Files|*.ppt?;*.pps?";

            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var filename = ofd.FileName;

                if( dsoOffice == null)
                {
                    MessageBox.Show(
                        "Office embedding control could not be loaded.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    return;
                }

                dsoOffice.OpenDocument(filename);
            }
        }

        private void SaveDocument_Click(object sender, RoutedEventArgs e)
        {
            dsoOffice.SaveDocument();
        }
    }
}
