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
        public async void Refresh()
        {
            ServiceUtils context = new ServiceUtils();

            await context.GetUnassignedStudents(OnGetUnassignedStudentsComplete);
        }
        #endregion

        #region Callbacks
        private void OnGetUnassignedStudentsComplete(IEnumerable<Student> students)
        {   
            List<LocalStudent> resultData = new List<LocalStudent>();

            foreach (Student s in students)
            {
                LocalStudent student = new LocalStudent()
                {
                    Record = s
                };

                resultData.Add(student);
            }

            this.Dispatcher.Invoke(() =>
            {
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
            });
        }
        #endregion

        #region Events
        private async void Student_Click(object sender, MouseButtonEventArgs e)
        {
            LocalStudent student = (sender as StudentPhoto).DataContext as LocalStudent;

            MessageBoxResult button = MessageBox.Show("Would you like to add the student?", "Student", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (button == MessageBoxResult.Yes)
            {
                ServiceUtils context = new ServiceUtils();
                await context.AddStudent(SessionContext.CurrentTeacher, student.Record);
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

