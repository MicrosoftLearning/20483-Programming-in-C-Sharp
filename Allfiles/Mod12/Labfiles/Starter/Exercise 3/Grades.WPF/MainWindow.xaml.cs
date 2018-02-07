using System;
using System.Windows;
using System.Collections.Generic;
using Grades.WPF.Services;
using System.Windows.Threading;
using System.Data.Services.Client;
using System.Threading.Tasks;
using Grades.WPF.GradesService.DataModel;

namespace Grades.WPF
{
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            ServiceUtils utils = new ServiceUtils();
            InitializeComponent();

            GotoLogon();
        }
        #endregion

        #region Events
        private void StartBusy(object sender, EventArgs e)
        {
            busyIndicator.Visibility = Visibility.Visible;
        }

        private void EndBusy(object sender, EventArgs e)
        {
            busyIndicator.Visibility = Visibility.Collapsed;
        }

        private void logonPage_LogonSuccess(object sender, EventArgs e)
        {
            Refresh();
        }

        private void studentsPage_StudentSelected(object sender, StudentEventArgs e)
        {
            SessionContext.CurrentStudent = e.Child;
            GotoStudentProfile();
        }

        private void studentProfile_Back(object sender, EventArgs e)
        {
            GotoStudentsPage();
        }

        private void Logoff_Click(object sender, RoutedEventArgs e)
        {
            logonPage.Logoff();
            GotoLogon();
        }
        #endregion

        #region Navigate
        public void GotoLogon()
        {
            gridLoggedIn.Visibility = Visibility.Collapsed;
            logonPage.Visibility = Visibility.Visible;
            studentsPage.Visibility = Visibility.Collapsed;
            studentProfile.Visibility = Visibility.Collapsed;

            logoLogon.Visibility = Visibility.Visible;
            logoMain.Visibility = Visibility.Collapsed;
        }

        public void GotoStudentsPage()
        {
            LoadSecondaryPage();

            studentsPage.Visibility = Visibility.Visible;
            studentProfile.Visibility = Visibility.Collapsed;

            studentsPage.Refresh();
        }

        public void GotoStudentProfile()
        {
            LoadSecondaryPage();

            studentsPage.Visibility = Visibility.Collapsed;
            studentProfile.Visibility = Visibility.Visible;

            if (SessionContext.Role == "Student")
                studentProfile.Refresh(SessionContext.UserName);
            else
                studentProfile.Refresh(SessionContext.CurrentStudent.FirstName, SessionContext.CurrentStudent.LastName);
        }

        public void LoadSecondaryPage()
        {
            gridLoggedIn.Visibility = Visibility.Visible;
            logonPage.Visibility = Visibility.Collapsed;

            logoLogon.Visibility = Visibility.Collapsed;
            logoMain.Visibility = Visibility.Visible;
        }
        #endregion

        #region Refresh
        public async void Refresh()
        {
            if (SessionContext.Role == "")
            {
                GotoLogon();
                return;
            }

            // Databind Name
            ServiceUtils utils = new ServiceUtils();

            try
            {
                switch (SessionContext.Role)
                {
                    case "Student":
                        // Get the details of the current user (which must be a student)
                        var student = await utils.GetStudent(SessionContext.UserName);

                        // Display the name of the student
                        try
                        {
                            LocalStudent localStudent = new LocalStudent();
                            localStudent.Record = student;
                            SessionContext.CurrentStudent = localStudent;
                            txtName.Text = String.Format("Welcome {0} {1}!", localStudent.FirstName, localStudent.LastName);                            
                        }
                        catch (DataServiceQueryException ex)
                        {
                            MessageBox.Show(String.Format("Error: {0} - {1}",
                                ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
                        }    

                        // Display the details of the student
                        GotoStudentProfile();
                        break;

                    case "Parent":
                        // Get the details of the current user (which must be a parent)
                        var parent = await utils.GetParent(SessionContext.UserName);

                        // Display the name of the parent
                        try
                        {
                            SessionContext.CurrentParent = parent;
                            txtName.Text = String.Format("Welcome {0} {1}!", parent.FirstName, parent.LastName);
                        }
                        catch (DataServiceQueryException ex)
                        {
                            MessageBox.Show(String.Format("Error: {0} - {1}",
                                ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
                        } 

                        // Find all the students that are children of this parent
                        await utils.GetStudentsByParent(SessionContext.UserName, OnGetStudentsByParentComplete);                        
                        break;

                    case "Teacher":
                        // Get the details of the current user (which must be a teacher)
                        var teacher = await utils.GetTeacher(SessionContext.UserName);

                        // Display the details for the teacher
                        try
                        {
                            SessionContext.CurrentTeacher = teacher;
                            txtName.Text = String.Format("Welcome {0} {1}!", teacher.FirstName, teacher.LastName);

                            // Display the students in the class taught by this teacher
                            GotoStudentsPage();
                        }
                        catch (DataServiceQueryException ex)
                        {
                            MessageBox.Show(String.Format("Error: {0} - {1}",
                                ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
                        }  
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error fetching details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Callbacks
         // Display the students for a parent
        private void OnGetStudentsByParentComplete(IEnumerable<Student> students)
        {
            // Display the details for the first child
            try
            {
                foreach (var s in students)
                {
                    LocalStudent child = new LocalStudent();
                    child.Record = s;

                    SessionContext.CurrentStudent = child;
                    this.Dispatcher.Invoke(() => { GotoStudentProfile(); });
                    break;
                }
            }
            catch (DataServiceQueryException ex)
            {
                MessageBox.Show(String.Format("Error: {0} - {1}",
                    ex.Response.StatusCode.ToString(), ex.Response.Error.Message));
            }  
        }
        #endregion
    }
}