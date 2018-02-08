using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades.DataModel;


namespace GradesPrototype.Services
{

    // Global context for operations performed by MainWindow
    public class SessionContext
    {
        public static Grades.DataModel.SchoolGradesDBEntities DBContext = new SchoolGradesDBEntities(new Uri("http://localhost:1650/Services/GradesWebDataService.svc"));

        public static Guid UserID;
        public static string UserName;
        public static Grades.DataModel.Role UserRole;
        public static Grades.DataModel.Student CurrentStudent;
        public static Grades.DataModel.Teacher CurrentTeacher;

        public static void Save()
        {
            DBContext.SaveChanges();
        }

        static SessionContext()
        {
            DBContext.MergeOption = System.Data.Services.Client.MergeOption.PreserveChanges;
        }
    }
}
