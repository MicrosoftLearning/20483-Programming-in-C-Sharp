using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;

namespace School
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        #region Predefined code

        WordWrapper wordWrapper = new WordWrapper();
        string ReportPath;
        string CombinedReportPath;

        public MainWindow()
        {
            InitializeComponent();
            ReportPath = @"E:\Mod13\Labfiles\Reports\";
            CombinedReportPath = @"ClassReport\ClassReport.xps";
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            folderBrowserDialog.SelectedPath = ReportPath;

            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                ReportPath = folderBrowserDialog.SelectedPath.ToString();
                folderPathTextBox.Text = ReportPath;
                decrypt.IsEnabled = true;
            }
        }

        #endregion

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            // Call the CombineEncryptedReports method.
            wordWrapper.CombineEncryptedReports(ReportPath, Path.Combine(ReportPath, CombinedReportPath));
            System.Windows.MessageBox.Show("Class report successfully printed.", "The School of Fine Arts", MessageBoxButton.OK);
        }
   
    }
}
