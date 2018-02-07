using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Data.Services.Client;
using System.Windows.Threading;
using Grades.WPF.Services;
using System.Threading.Tasks;
using Grades.WPF.GradesService.DataModel;

namespace Grades.WPF
{
    public partial class AddStudentDialog : Window
    {
        #region Constructor
        public AddStudentDialog()
        {
            InitializeComponent();

            Refresh();
        }
        #endregion

        #region Refresh
        public void Refresh()
        {
            ServiceUtils utils = new ServiceUtils();

            var students = utils.GetUnassignedStudents();
                               
            List<LocalStudent> resultData = new List<LocalStudent>();

            foreach (Student s in students)
            {
                LocalStudent student = new LocalStudent()
                {
                    Record = s
                };

                resultData.Add(student);
            }

            list.ItemsSource = null;
            list.ItemsSource = resultData;

            if (resultData.Count == 0)
            {
                txtMessage.Visibility = Visibility.Visible;
                listContainer.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtMessage.Visibility = Visibility.Collapsed;
                listContainer.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Events
        private void Student_Click(object sender, MouseButtonEventArgs e)
        {
            LocalStudent student = (sender as StudentPhoto).DataContext as LocalStudent;

            MessageBoxResult button = MessageBox.Show("Would you like to add the student?", "Student", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (button == MessageBoxResult.Yes)
            {
                ServiceUtils utils = new ServiceUtils();
                utils.AddStudent(SessionContext.CurrentTeacher, student.Record);
                Refresh();
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        #endregion
    }
}

