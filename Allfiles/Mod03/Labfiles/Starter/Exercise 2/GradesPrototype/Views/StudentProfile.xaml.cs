using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // If the user is not a teacher, do nothing
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
        #endregion

        // Display the details for the current student including the grades for the student
        // The name of the student is available in the CurrentStudent property of the global context
        // Grades data is hardcoded in the XAML code for the StudentProfile view in this version of the prototype
        public void Refresh()
        {
            // Parse the student name into the first name and last name by using a regular expression
            // The firstname is the initial string up to the first space character.
            // The lastname is the string after the space character
            Match matchNames = Regex.Match(SessionContext.CurrentStudent, @"([^ ]+) ([^ ]+)");
            if (matchNames.Success)
            {
                string firstName = matchNames.Groups[1].Value; // Indexing in the Groups collection starts at 1, not 0
                string lastName = matchNames.Groups[2].Value;

                // Display the first name and last name in the TextBlock controls in the studentName StackPanel
                ((TextBlock)studentName.Children[0]).Text = firstName;
                ((TextBlock)studentName.Children[1]).Text = lastName;
            }

            // If the current user is a student, hide the Back button 
            // (only applicable to teachers who can use the Back button to return to the list of students)
            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
            }
        }
    }
}
