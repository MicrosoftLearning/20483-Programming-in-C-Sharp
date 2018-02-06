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
using GradesPrototype.Services;

namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for AssignStudentDialog.xaml
    /// </summary>
    public partial class AssignStudentDialog : Window
    {
        public AssignStudentDialog()
        {
            InitializeComponent();
        }

        // TODO: Exercise 4: Task 3b: Refresh the display of unassigned students
        private void Refresh()
        {
            
        }

        private void AssignStudentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        // TODO: Exercise 4: Task 3a: Enroll a student in the teacher's class
        private void Student_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog box
            this.Close();
        }
    }
}
