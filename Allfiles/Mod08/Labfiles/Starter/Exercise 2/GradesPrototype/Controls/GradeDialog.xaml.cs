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
using GradesPrototype.Services;
using Grades.DataModel;

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
            foreach (Subject subj in SessionContext.DBContext.Subjects)
            {
                subject.Items.Add(subj.Name);
            }
 
             // Set default values for the assessment date and subject
            assessmentDate.SelectedDate = DateTime.Now;
            subject.SelectedValue = subject.Items[0];
        }

        // If the user clicks OK to save the Grade details, validate the information that the user has provided
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            // Create a Grade object and use it to trap and report any data validation exceptions that are thrown
            try
            {
                Grades.DataModel.Grade testGrade = new Grades.DataModel.Grade();

                testGrade.ValidateAssessmentDate(assessmentDate.SelectedDate.Value);

                testGrade.ValidateAssessmentGrade(assessmentGrade.Text);
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
