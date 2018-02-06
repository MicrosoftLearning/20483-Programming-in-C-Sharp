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
        public event EventHandler LogonFailed;
        #endregion

        #region Logon Validation

        // Validate the username and password against the Users collection in the MainWindow window
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            // Find the user in the list of possible users - first check whether the user is a Teacher
            var teacher = (from Teacher t in DataSource.Teachers
                           where String.Compare(t.UserName, username.Text) == 0
                           && t.VerifyPassword(password.Password)
                           select t).FirstOrDefault();

            // If the UserName of the user retrieved by using LINQ is non-empty then the user is a teacher
            if (teacher != null && !String.IsNullOrEmpty(teacher.UserName))
            {
                // Save the UserID and Role (teacher or student) and UserName in the global context
                SessionContext.UserID = teacher.TeacherID;
                SessionContext.UserRole = Role.Teacher;
                SessionContext.UserName = teacher.UserName;
                SessionContext.CurrentTeacher = teacher; 
              
                // Raise the LogonSuccess event and finish
                LogonSuccess(this, null);
                return;
            }
            // If the user is not a teacher, check whether the username and password match those of a student
            else
            {
                var student = (from Student s in DataSource.Students
                               where String.Compare(s.UserName, username.Text) == 0
                               && s.VerifyPassword(password.Password)
                               select s).FirstOrDefault();

                // If the UserName of the user retrieved by using LINQ is non-empty then the user is a student
                if (student != null && !String.IsNullOrEmpty(student.UserName))
                {
                    // Save the details of the student in the global context
                    SessionContext.UserID = student.StudentID;
                    SessionContext.UserRole = Role.Student;
                    SessionContext.UserName = student.UserName;
                    SessionContext.CurrentStudent = student; 
                    
                    // Raise the LogonSuccess event and finish
                    LogonSuccess(this, null);
                    return;
                }
            }

            // If the credentials do not match those for a Teacher or for a Student then they must be invalid
            // Raise the LogonFailed event
            LogonFailed(this, null);
        }
        #endregion
    }
}
