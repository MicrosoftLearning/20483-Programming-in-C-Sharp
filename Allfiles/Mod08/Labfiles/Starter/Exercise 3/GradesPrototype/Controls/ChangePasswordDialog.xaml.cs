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
using System.Windows.Shapes;
using GradesPrototype.Services;
using Grades.DataModel;


namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        // If the user clicks OK to change the password, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // Get the details of the current user
            Grades.DataModel.User currentUser;
            if (SessionContext.UserRole == Role.Teacher)
            {
                currentUser = SessionContext.CurrentTeacher.User;
            }
            else
            {
                currentUser = SessionContext.CurrentStudent.User;
            }

             // Check that the old password is correct for the current user
            string oldPwd = oldPassword.Password;
            if (!currentUser.VerifyPassword(oldPwd))
            {
                MessageBox.Show("Old password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            // Check that the new password and confirm password fields are the same
            string newPwd = newPassword.Password;
            string confirmPwd = confirm.Password;

            if (String.Compare(newPwd, confirmPwd) != 0)
            {
                MessageBox.Show("The new password and confirm password fields are different", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Attempt to change the password
            // If the password is not sufficiently complex, display an error message
            if (!currentUser.SetPassword(SessionContext.UserRole , newPwd))
            {
                MessageBox.Show("The new password is not sufficiently complex", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            SessionContext.DBContext.UpdateObject(currentUser);
            SessionContext.Save();

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
