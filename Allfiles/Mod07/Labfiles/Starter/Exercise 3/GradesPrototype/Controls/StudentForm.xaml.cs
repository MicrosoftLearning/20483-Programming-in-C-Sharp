using System;
using System.Windows;

namespace WoodgroveSchool.Controls
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
            // Check that the user has provided a first name
            if (String.IsNullOrEmpty(this.firstName.Text))
            {
                MessageBox.Show("The student must have a first name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check that the user has provided a last name
            if (String.IsNullOrEmpty(this.lastName.Text))
            {
                MessageBox.Show("The student must have a last name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check that the user has provided a new password
            if (String.IsNullOrEmpty(this.password.Text))
            {
                MessageBox.Show("The student must have a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Indicate that the data is valid
            this.DialogResult = true;
        }
    }
}
