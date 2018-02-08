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
        public void Refresh()
        {
            
        }
        #endregion

        #region Events
        private void Student_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        #endregion
    }
}

