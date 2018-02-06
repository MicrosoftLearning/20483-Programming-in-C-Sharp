using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradesPrototype.Data;

namespace GradesPrototype.Services
{
    // Global context for operations performed by MainWindow
    public static class SessionContext
    {
        public static int UserID;
        public static string UserName;
        public static Role UserRole;
        public static Student CurrentStudent;
        public static Teacher CurrentTeacher;
    }
}
