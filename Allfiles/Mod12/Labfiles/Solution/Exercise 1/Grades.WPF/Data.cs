using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using Grades.WPF.GradesService.DataModel;
using Grades.Utilities;

namespace Grades.WPF
{
    public class LocalStudent
    {
        public Student Record { get; set; }

        public Guid ID
        {
            get { return Record.UserId; }
        }

        public string Name
        {
            get { return String.Format("{0} {1}", Record.FirstName, Record.LastName); }
        }

        public string File
        {
            get { return String.Format(@"{0}Images/Portraits/{1}", @"http://localhost:1103/", Record.ImageName); }
        }

        public string FirstName
        {
            get { return Record.FirstName; }
        }

        public string LastName
        {
            get { return Record.LastName; }
        }
    }

    public class LocalGrade : IDataErrorInfo
    {
        #region Properties
        public Grade Record { get; set; }

        #region Readonly Properties

        [IncludeInReport(Label="Subject Name", Bold=true, Underline=true)]
        public string SubjectName
        {
            get { return (Record.Subject != null) ? Record.Subject.Name : ""; }
        }

        [IncludeInReport (Label="Date")]
        public string AssessmentDateString
        {
            get { return Record.AssessmentDate.ToShortDateString(); }
        }
        #endregion

        #region Form Properties
        public DateTime AssessmentDate
        {
            get { return Record.AssessmentDate; }
            set { Record.AssessmentDate = value; }
        }

        public Student CurrentStudent
        {
            get { return Record.Student; }
            set
            {
                Record.Student = value;
                Record.StudentUserId = value.UserId;
            }
        }

        public Subject CurrentSubject
        {
            get { return Record.Subject; }
            set
            {
                Record.Subject = value;
                Record.SubjectId = value.Id;
            }
        }

        [IncludeInReport(Label = "Grade")]
        public string Assessment
        {
            get { return Record.Assessment; }
            set { Record.Assessment = value; }
        }

        [IncludeInReport(Label = "Comments")]
        public string Comments
        {
            get { return Record.Comments; }
            set { Record.Comments = value; }
        }
        #endregion
        #endregion

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get {
                string result = null;

                if (columnName == "AssessmentDate")
                {
                    if (AssessmentDate == null || AssessmentDate.Year < 2000)
                        result = "Invalid Date";
                }
                else if (columnName == "Assessment")
                {
                    // Use a regular expression to check that the supplied
                    // assessment grade is in the range A-E. Also allow a - or a +
                    if (Assessment != null)
                    {
                        Match regMatch = Regex.Match(Assessment, @"^[A-E][+-]?$");
                        if (!regMatch.Success)
                        {
                            result = "An assessment must be A - E, with optional + or -";
                        }
                    }
                }

                return result;
            }
        }
    }

    public class FilterCriteria
    {
        public Subject CurrentSubject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ListColorConverter : IValueConverter
    {
        static bool flag = false;
        SolidColorBrush brush1 = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        SolidColorBrush brush2 = new SolidColorBrush(Color.FromArgb(28, 0, 140, 255));
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            flag = !flag;
            return flag ? brush1 : brush2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static void Reset()
        {
            flag = false;
        }
    }
}
