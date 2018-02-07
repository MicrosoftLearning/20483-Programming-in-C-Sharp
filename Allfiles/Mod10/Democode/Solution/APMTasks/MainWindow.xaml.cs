using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace APMTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnCheckUrl_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;
            if (!String.IsNullOrEmpty(url))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);                    
                    HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
                    lblResult.Content = String.Format("The URL returned the following status code: {0}", response.StatusCode);
                }
                catch (Exception ex)
                {
                    lblResult.Content = ex.Message;
                }

            }
            else
            {
                lblResult.Content = String.Empty;
            }
        }        
    }
}
