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
using System.Windows.Shapes;
using GradesPrototype.Data;

namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for GradeDialog.xaml
    /// </summary>
    public partial class GradeDialog : Window
    {
        public GradeDialog()
        {
            InitializeComponent();
        }

        private void GradeDialog_Loaded(object sender, RoutedEventArgs e)
        {
            // Display the list of available subjects in the subject ListBox
            subject.ItemsSource = DataSource.Subjects;

            // Set default values for the assessment date and subject
            assessmentDate.SelectedDate = DateTime.Now;
            subject.SelectedValue = subject.Items[0];
        }

        // If the user clicks OK to save the Grade details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // Use the validation built into the Grade class to validate the user input
            // Create a Grade object using the details provided, and trap and report any exceptions that are thrown
            try
            {
                Grade testGrade = new Grade(0, assessmentDate.SelectedDate.Value.ToString("d"), subject.SelectedValue.ToString(), assessmentGrade.Text, comments.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error creating assessment", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }            

            // Indicate that the data is valid
            this.DialogResult = true;
        }

    }
}
