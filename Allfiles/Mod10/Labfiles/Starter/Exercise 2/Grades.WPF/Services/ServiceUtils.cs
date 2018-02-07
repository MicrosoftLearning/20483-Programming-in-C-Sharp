using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Services.Client;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using Grades.WPF.GradesService.DataModel;

namespace Grades.WPF.Services
{
    class ServiceUtils
    {
        #region Data Members
        public static GradesEntities DBContext;
        public static List<Subject> Subjects { get; set; }
        #endregion

        #region Constructor
        public ServiceUtils()
        {
            if (DBContext == null)
            {
                DBContext = new GradesEntities(
                    new Uri("http://localhost:1103/Services/GradesWebDataService.svc", UriKind.Absolute));

                if (Subjects == null)
                {
                    GetSubjects();
                }
            }
        }
        #endregion

        #region Teacher
        public async Task<Teacher> GetTeacher(string userName)
        {
            if (!IsConnected())
                return null;

            var teacher = await Task.Run(() =>
                            (from t in DBContext.Teachers
                             where t.User.UserName == userName
                             select t).FirstOrDefault());

            return teacher;
        }

        public async Task GetStudentsByTeacher(string teacherName, Action<IEnumerable<Student>> callback)
        {
            if (!IsConnected())
                return;

            // Fetch students by using the GradesService service
            var students = await Task.Run(() =>
                                        (from s in DBContext.Students
                                         where s.Teacher.User.UserName == teacherName
                                         select s).OrderBy(s => s.LastName).ToList());

            // Invoke the callback that displays the result asynchronously
            await Task.Run(() => callback(students));
        }

        public void AddStudent(Teacher teacher, Student student)
        {
            if (!IsConnected())
                return;

            if (student == null || teacher == null)
                return;

            student.Teacher = teacher;
            student.TeacherUserId = teacher.UserId;
            DBContext.UpdateObject(student);
            Save();
        }

        public void RemoveStudent(Teacher teacher, Student student)
        {
            if (!IsConnected())
                return;

            if (student == null || teacher == null)
                return;

            student.Teacher = null;
            student.TeacherUserId = null;
            DBContext.UpdateObject(student);
            Save();
        }

        #endregion

        #region Parent
        public Parent GetParent(string userName)
        {
            if (!IsConnected())
                return null;

            var parent = (from p in DBContext.Parents
                          where p.User.UserName == userName
                          select p).FirstOrDefault();

            return parent;
        }

        public IEnumerable<Student> GetStudentsByParent(string parentName)
        {
            if (!IsConnected())
                return null;

            Uri url = new Uri(String.Format("http://localhost:1103/Services/GradesWebDataService.svc/StudentsForParent?parentName='{0}'", parentName), UriKind.RelativeOrAbsolute);
            var students = DBContext.Execute<Student>(url);

            return students;
        }
        #endregion

        #region Student
        public List<Student> GetUnassignedStudents()
        {
            if (!IsConnected())
                return null;

            var students = (from s in DBContext.Students
                            where s.TeacherUserId == null
                            select s).OrderBy(s => s.LastName).ToList();

            return students;
        }            

        public Student GetStudent(string userName)
        {
            if (!IsConnected())
                return null;

            var student = (from s in DBContext.Students
                           where s.User.UserName == userName
                           select s).FirstOrDefault();

            return student;
        }

        public Student GetStudent(string firstname, string lastname)
        {
            if (!IsConnected())
                return null;

            var student = (from s in DBContext.Students
                           where s.FirstName == firstname && s.LastName == lastname
                           select s).FirstOrDefault();

            return student;
        }

        public string GetClassNameByStudent(Guid studentID)
        {
            if (!IsConnected())
                return null;

            var classname = (from s in DBContext.Students
                             where s.User.UserId == studentID
                             select s.Teacher.Class).FirstOrDefault();

            return classname;
        }

        public List<Grade> GetGradesByStudent(Guid studentID)
        {
            if (!IsConnected())
                return null;

            var grades = (from g in DBContext.Grades
                          where g.StudentUserId == studentID
                          select g).ToList();

            return grades;
        }
        #endregion

        #region Grades
        private List<Subject> GetSubjects()
        {
            if (!IsConnected())
                return null;

            // Find all the subjects in the dataservice for the current student and add them to the Subjects collection
            var subs = (from s in DBContext.Subjects
                        select s).OrderBy(s => s.Name).ToList();

            Subjects = new List<Subject>();

            foreach (Subject s in subs)
                Subjects.Add(s);

            return Subjects;
        }

        public static Subject GetSubject(int id)
        {
            if (Subjects.Count == 0)
                return null;

            return Subjects.First(s => s.Id == id);
        }

        public void AddGrade(Grade grade)
        {
            DBContext.AddToGrades(grade);
            Save();
        }

        public void UpdateGrade(Grade grade)
        {
            if (!IsConnected())
                return;

            DBContext.UpdateObject(grade);
            Save();
        }
        #endregion

        #region Helper Methods
        public bool IsConnected()
        {
            return DBContext != null;
        }

        public void Save()
        {
            DBContext.SaveChanges(SaveChangesOptions.Batch);
        }
        #endregion
    }
}