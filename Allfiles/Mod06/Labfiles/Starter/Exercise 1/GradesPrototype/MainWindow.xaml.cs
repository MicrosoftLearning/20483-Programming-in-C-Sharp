using System;
using System.Collections;
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
using GradesPrototype.Controls;
using GradesPrototype.Data;
using GradesPrototype.Services;
using GradesPrototype.Views;

namespace GradesPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataSource.CreateData();
            DataSource.Students.Sort();
            GotoLogon();
        }

        #region Navigation
        // Display the logon view
        public void GotoLogon()
        {
            // Display the logon view and hide the list of students and single student view
            logonPage.Visibility = Visibility.Visible;
            studentsPage.Visibility = Visibility.Collapsed;
            studentProfile.Visibility = Visibility.Collapsed;
        }

        // Display the list of students
        private void GotoStudentsPage()
        {            
            // Hide the view for a single student (if it is visible)
            studentProfile.Visibility = Visibility.Collapsed;

            // Display the list of students
            studentsPage.Visibility = Visibility.Visible;
            studentsPage.Refresh();
        }

        // Display the details for a single student
        public void GotoStudentProfile()
        {
            // Hide the list of students
            studentsPage.Visibility = Visibility.Collapsed;

            // Display the view for a single student
            studentProfile.Visibility = Visibility.Visible;
            studentProfile.Refresh();
        }
        #endregion

        #region Event Handlers

        // Handle successful logon
        private void Logon_Success(object sender, EventArgs e)
        {
            // Update the display and show the data for the logged on user
            logonPage.Visibility = Visibility.Collapsed;
            gridLoggedIn.Visibility = Visibility.Visible;
            Refresh();
        }

        // Handle logon failure
        private void Logon_Failed(object sender, EventArgs e)
        {
            // Display an error message. The user must try again
            MessageBox.Show("Invalid Username or Password", "Logon Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        // Handle logoff
        private void Logoff_Click(object sender, RoutedEventArgs e)
        {
            // Hide all views apart from the logon view
            gridLoggedIn.Visibility = Visibility.Collapsed;
            studentsPage.Visibility = Visibility.Collapsed;
            studentProfile.Visibility = Visibility.Collapsed;
            logonPage.Visibility = Visibility.Visible;
        }

        // Handle change password request
        private void ChangePassword_Click(object sender, EventArgs e)
        {
            // Use the ChangePasswordDialog to change the user's password
            ChangePasswordDialog cpd = new ChangePasswordDialog();

            // Display the dialog
            if (cpd.ShowDialog().Value)
            {
                // When the user closes the dialog by using the OK button, the password should have been changed
                // Display a message to confirm
                MessageBox.Show("Password changed", "Password", MessageBoxButton.OK, MessageBoxImage.Information);
            }            
        }

        // Handle the Back button on the Student view
        private void studentPage_Back(object sender, EventArgs e)
        {
            GotoStudentsPage();
        }

        // Handle the StudentSelected event when the user clicks a student on the Students view
        private void studentsPage_StudentSelected(object sender, StudentEventArgs e)
        {
            SessionContext.CurrentStudent = e.Child;
            GotoStudentProfile();
        }
        #endregion

        #region Display Logic

        // Update the display for the logged on user (student or teacher)
        private void Refresh()
        {
            switch (SessionContext.UserRole)
            {
                case Role.Student:
                    // Display the student name in the banner at the top of the page
                    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentStudent.FirstName, SessionContext.CurrentStudent.LastName);

                    // Display the details for the current student
                    GotoStudentProfile();
                    break;

                case Role.Teacher:
                    // Display the teacher name in the banner at the top of the page
                    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentTeacher.FirstName, SessionContext.CurrentTeacher.LastName);

                    // Display the list of students for the teacher
                    GotoStudentsPage();                    
                    break;
            }
        }
        #endregion
    }
}
