using System;
using System.Collections.Generic;
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
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for LogonPage.xaml
    /// </summary>
    public partial class LogonPage : UserControl
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        #region Event Members
        public event EventHandler LogonSuccess;

        // TODO: Exercise 3: Task 1a: Define LogonFailed event

        #endregion

        #region Logon Validation

        // TODO: Exercise 3: Task 1b: Validate the username and password against the Users collection in the MainWindow window
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion
    }
}
