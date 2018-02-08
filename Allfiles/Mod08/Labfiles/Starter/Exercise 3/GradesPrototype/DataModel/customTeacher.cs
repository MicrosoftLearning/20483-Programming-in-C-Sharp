using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradesPrototype.Services;

namespace Grades.DataModel
{
    public partial class Teacher
    {
        private const int MAX_CLASS_SIZE = 8;

        public void EnrollInClass(Student student)
        {
            // Verify that this teacher's class is not already full.
            // Determine how many students are currently in the class.
            int numStudents = (from s in SessionContext.DBContext.Students
                               where s.TeacherUserId == UserId
                               select s).Count();

            // If the class is already full, another student cannot be enrolled.
            if (numStudents >= MAX_CLASS_SIZE)
            {
                // So throw a ClassFullException and specify the class that is full.
                throw new ClassFullException("Class full: Unable to enroll student", Class);
            }
            // Verify that the student is not already enrolled in another class.
            if (student.TeacherUserId == null)
            {
                // Set the TeacherID property of the student.
                student.TeacherUserId = UserId;
            }
            else
            {
                // If the student is already assigned to a class, throw an ArgumentException.
                throw new ArgumentException("Student", "Student is already assigned to a class");
            }
        }


    }
}
