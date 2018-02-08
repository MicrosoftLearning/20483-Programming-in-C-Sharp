using System;
using System.Windows;
using Grades.WPF.GradesService.DataModel;
using Grades.WPF.Services;

namespace Grades.WPF
{
    public partial class AddGradeDialog : Window
    {
        #region Data Members
        private LocalGrade _grade;
        #endregion

        #region Constructor
        public AddGradeDialog()
        {
            InitializeComponent();

            _grade = new LocalGrade();
            _grade.Record = new Grade();
            _grade.CurrentSubject = ServiceUtils.Subjects[0];
            _grade.CurrentStudent = SessionContext.CurrentStudent.Record;
            _grade.AssessmentDate = DateTime.Now;
            _grade.Assessment = "A";
            this.DataContext = _grade;
        }
        #endregion

        #region Events
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceUtils utils = new ServiceUtils();
            utils.AddGrade(_grade.Record);
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion
    }
}

