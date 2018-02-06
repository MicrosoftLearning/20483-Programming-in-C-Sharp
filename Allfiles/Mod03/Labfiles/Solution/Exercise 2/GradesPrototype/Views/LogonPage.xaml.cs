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

        #endregion

        #region Logon Validation

        // Simulate logging on (no validation or authentication performed yet)
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            // Save the username and role (type of user) specified on the form in the global context
            SessionContext.UserName = username.Text;
            SessionContext.UserRole = (bool)userrole.IsChecked ? Role.Teacher : Role.Student;

            // If the role is Student, set the CurrentStudent property in the global context to a dummy student; Eric Gruber
            if (SessionContext.UserRole == Role.Student)
            {
                SessionContext.CurrentStudent = "Eric Gruber";
            }

            // Raise the LogonSuccess event
            if (LogonSuccess != null)
            {
                LogonSuccess(this, null);
            }
        }
        #endregion
    }
}
