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
using GradesPrototype.Data;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : UserControl
    {
        public StudentsPage()
        {
            InitializeComponent();
        }

        #region Display Logic

        // Display students for the current teacher
        // Student details are hard coded in the XAML definition of the view
        public void Refresh()
        {
            // Display the class name - hard-coded
            txtClass.Text = "3A";
        }
        #endregion

        #region Event Members
        public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        public event StudentSelectionHandler StudentSelected;
        #endregion

        #region Event Handlers
        private void Student_Click(object sender, RoutedEventArgs e)
        {
            Button itemClicked = sender as Button;
            if (itemClicked != null)
            {
                // Find out which student was clicked - the Tag property of the button contains the name
                string studentName = (string)itemClicked.Tag;
                if (StudentSelected != null)
                {
                    // Raise the StudentSelected event (handled by MainWindow) to display the details for this student
                    StudentSelected(sender, new StudentEventArgs(studentName));
                }
            }
        }
        #endregion
    }

    // EventArgs class for passing Student information to an event
    public class StudentEventArgs : EventArgs
    {
        public string Child { get; set; }

        public StudentEventArgs(string s)
        {
            Child = s;
        }
    }
}
