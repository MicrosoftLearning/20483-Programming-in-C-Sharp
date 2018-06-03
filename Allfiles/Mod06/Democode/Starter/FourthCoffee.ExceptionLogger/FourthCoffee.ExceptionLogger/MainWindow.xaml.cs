using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _exceptionsRootPath;
        string _filePath;

        public MainWindow()
        {
            InitializeComponent();

            this._exceptionsRootPath = ConfigurationManager.AppSettings["rootPath"];
            this.ResetUI();
            this.LoadExistingEntries();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            this.ResetUI();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            var fileToLoad = this.files.SelectedValue as string;

            if (string.IsNullOrEmpty(fileToLoad))
            {
                MessageBox.Show(
                  "You must select a file.",
                  "Load Error",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
            else if (!File.Exists(fileToLoad))
            {
                MessageBox.Show(
                  "Could not find the file specified.",
                  "Load Error",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
            else
            {
                var entry = ExceptionSerializer.Deserialize(fileToLoad);

                this.errorTitle.Text = entry.Title;
                this.errorText.Text = entry.Details;
                this._filePath = fileToLoad;
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.errorTitle.Text) || string.IsNullOrEmpty(this.errorText.Text))
            {
                MessageBox.Show(
                    "You must provide a title and exception details.",
                    "Save Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                var entry = new ExceptionEntry
                {
                    Title = this.errorTitle.Text,
                    Details = this.errorText.Text
                };

                var savePath = this.GenerateSavePath();

                ExceptionSerializer.Serialize(entry, savePath);

                MessageBox.Show(
                    "Exception saved.",
                    "Save Successful",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                this.ResetUI();
                this.LoadExistingEntries();
            }
        }

        private void LoadExistingEntries()
        {
            this.files.Items.Clear();

            var sourceFiles = Directory.GetFiles(this._exceptionsRootPath);

            foreach (var file in sourceFiles)
                this.files.Items.Add(file);
        }

        private string GenerateSavePath()
        {
            if (string.IsNullOrEmpty(this._filePath))
            {
                var fileName = string.Format("Exception_{0:MM_dd_yy H_mm_ss}.json", DateTime.Now);

                return System.IO.Path.Combine(this._exceptionsRootPath, fileName);
            }
            else
            {
                return this._filePath;
            }


        }

        private void ResetUI()
        {
            this._filePath = string.Empty;
            this.errorTitle.Text = string.Empty;
            this.errorText.Text = string.Empty;
        }
    }
}
