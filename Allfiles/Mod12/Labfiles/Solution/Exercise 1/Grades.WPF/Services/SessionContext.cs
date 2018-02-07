using System.Collections.Generic;
//using Grades.WPF.GradesService;
using Grades.WPF.GradesService.DataModel;


namespace Grades.WPF.Services
{
    public class SessionContext
    {
        #region Public Members
        public static string UserName { get; set; }
        public static string Role { get; set; }

        public static Teacher CurrentTeacher { get; set; }
        public static Parent CurrentParent { get; set; }
        public static LocalStudent CurrentStudent { get; set; }

        public static List<LocalGrade> CurrentGrades { get; set; }
        #endregion

        #region Public Methods
        public static void Logon(string userName, string role)
        {
            UserName = userName;
            Role = role;
        }

        public static void Logoff()
        {
            UserName = "";
            Role = "";
            CurrentStudent = null;
            CurrentTeacher = null;
            CurrentParent = null;
        }
        #endregion
    }
}
