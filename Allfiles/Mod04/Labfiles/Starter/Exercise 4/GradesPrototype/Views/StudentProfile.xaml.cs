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

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : UserControl
    {
        public StudentProfile()
        {
            InitializeComponent();
        }

        #region Event Members
        public event EventHandler Back;
        #endregion

        #region Events
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            // If the user is not a teacher, do nothing (the button should not appear anyway)
            if (SessionContext.UserRole != Role.Teacher)
            {
                return;
            }

            // If the user is a teacher, raise the Back event
            // The MainWindow page has a handler that catches this event and returns to the Students page
            if (Back != null)
            {
                Back(sender, e);
            }
        }

        // TODO: Exercise 4: Task 4a: Enable a teacher to remove a student from a class
        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        // TODO: Exercise 4: Task 5a: Enable a teacher to add a grade to a student
        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        // Display the details for the current student (held in SessionContext.CurrentStudent), including the grades for the student
        public void Refresh()
        {
            // Bind the studentName StackPanel to display the details of the student in the TextBlocks in this panel
            studentName.DataContext = SessionContext.CurrentStudent;

            // If the current user is a student, hide the Back, Remove, and Add Grade buttons
            // (these features are only applicable to teachers)
            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
                btnRemove.Visibility = Visibility.Hidden;
                btnAddGrade.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
                btnAddGrade.Visibility = Visibility.Visible;
            }

            // Find all the grades for the student
            List<Grade> grades = new List<Grade>();
            foreach (Grade grade in DataSource.Grades)
            {
                if (grade.StudentID == SessionContext.CurrentStudent.StudentID)
                {
                    grades.Add(grade);
                }
            }
            
            // Display the grades in the studentGrades ItemsControl by using databinding
            studentGrades.ItemsSource = grades;
        }
    }
}
