using System;
using System.Windows;

namespace School
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        #region Predefined code

        public StudentForm()
        {
            InitializeComponent();
        }

        #endregion

        // If the user clicks OK to save the Student details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Exercise 2: Task 2a: Check that the user has provided a first name
            // TODO: Exercise 2: Task 2b: Check that the user has provided a last name
            // TODO: Exercise 2: Task 3a: Check that the user has entered a valid date for the date of birth
            // TODO: Exercise 2: Task 3b: Verify that the student is at least 5 years old

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
