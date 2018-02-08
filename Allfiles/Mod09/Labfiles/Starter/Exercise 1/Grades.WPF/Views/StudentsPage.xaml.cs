using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using Grades.WPF.Services;
using System.Data.Services.Client;
using System.Windows.Threading;
using System.Threading.Tasks;
using Grades.WPF.GradesService.DataModel;

namespace Grades.WPF
{
    public partial class StudentsPage : UserControl
    {
        #region Constructor
        public StudentsPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Members
        public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        public event StudentSelectionHandler StudentSelected;
        #endregion

        #region Refresh
        public void Refresh()
        {
            // Find all students for the current teacher
            ServiceUtils utils = new ServiceUtils();

            var students = utils.GetStudentsByTeacher(SessionContext.UserName);

            // Iterate through the returned set of students, construct a local student object list
            List<LocalStudent> resultData = new List<LocalStudent>();

            foreach (Student s in students)
            {
                LocalStudent student = new LocalStudent()
                {
                    Record = s
                };
                resultData.Add(student);
            }

            // TODO: Exercise 1: Task 5a: Bind the list of students to the "list" ItemsControl
            

            txtClass.Text = String.Format("Class {0}", SessionContext.CurrentTeacher.Class);


            txtClass.Text = String.Format("Class {0}", SessionContext.CurrentTeacher.Class);
 
        }
        #endregion

        #region Callbacks
        
        #endregion

        #region Events

        // TODO: Exercise 1: Task 4b: Review the following event handler.
        //Animate the photo as the user moves the mouse over the "delete" image
        private void RemoveStudent_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            grid.Opacity = 1.0;
            StudentPhoto photo = ((Grid)grid.Parent).Children[0] as StudentPhoto;
            photo.Opacity = 0.6;
        }

        // TODO: Exercise 1: Task 4c: Review the following event handler.
        // Animate the photo as the user moves the mouse away from the "delete" image
        private void RemoveStudent_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)sender;
            grid.Opacity = 0.3;
            StudentPhoto photo = ((Grid)grid.Parent).Children[0] as StudentPhoto;
            photo.Opacity = 1.0;
        }

        // TODO: Exercise 1: Task 3b: Review the following event handler.
        // If the user clicks a photo, raise the StudentSelected event to display the details of the student
        private void Student_Click(object sender, MouseButtonEventArgs e)
        {
            if (StudentSelected != null)
                StudentSelected(sender, new StudentEventArgs((sender as StudentPhoto).DataContext as LocalStudent));
        }

        private void StudentText_Click(object sender, MouseButtonEventArgs e)
        {
            if (StudentSelected != null)
                StudentSelected(sender, new StudentEventArgs((sender as TextBlock).Tag as LocalStudent));
        }

        private void AddStudent_Click(object sender, MouseButtonEventArgs e)
        {
            AddStudentDialog dialog = new AddStudentDialog();
            dialog.Closed += new EventHandler(dialog_Closed);
            dialog.ShowDialog();
        }

        private void dialog_Closed(object sender, EventArgs e)
        {
            Refresh();
        }

        // TODO: Exercise 1: Task 4d: Review the following event handler.
        // Remove the student from the class if the user clicks the remove icon
        private void RemoveStudent_Click(object sender, MouseButtonEventArgs e)
        {
            LocalStudent student = (sender as Grid).Tag as LocalStudent;

            MessageBoxResult button = MessageBox.Show("Would you like to remove the student?", "Student", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (button == MessageBoxResult.Yes)
            {
                ServiceUtils utils = new ServiceUtils();
                utils.RemoveStudent(SessionContext.CurrentTeacher, student.Record);
                Refresh();
            }
        }
        #endregion

    }

    public class StudentEventArgs : EventArgs
    {
        public LocalStudent Child { get; set; }

        public StudentEventArgs(LocalStudent s)
        {
            Child = s;
        }
    }
}
