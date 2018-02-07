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

        private void btnCheckUrl_Click(object sender, RoutedEventArgs e)
        {
            string url = txtUrl.Text;
            if (!String.IsNullOrEmpty(url))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.BeginGetResponse(new AsyncCallback(ResponseCallback), request);
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

        private void ResponseCallback(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
            lblResult.Dispatcher.BeginInvoke(new Action(() =>
                {
                    lblResult.Content = String.Format("The URL returned the following status code: {0}", response.StatusCode);
                }));
        }
    }
}
