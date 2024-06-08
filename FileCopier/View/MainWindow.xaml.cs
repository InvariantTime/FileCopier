using FileCopier.Services;
using FileCopier.Services.Interfaces;
using FileCopier.ViewModels;
using System.Windows;
using WinForms = System.Windows.Forms;

namespace FileCopier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IFileCopierService copier = new FileCopierService();
            DataContext = new FileCopierViewModel(copier);
        }

        private void OpenSourceFolder(object sender, RoutedEventArgs e)
        {
            _sourceBox.Text = OpenFolder();
        }

        private void OpenOutputFolder(object sender, RoutedEventArgs e)
        {
            _outputBox.Text = OpenFolder();
        }

        private static string OpenFolder()
        {
            var dialog = new WinForms.FolderBrowserDialog();
            dialog.Description = "Select folder";

            var result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
                return dialog.SelectedPath;

            return string.Empty;
        }
    }
}