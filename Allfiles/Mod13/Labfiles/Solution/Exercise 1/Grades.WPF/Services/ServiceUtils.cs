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

        public async Task AddStudent(Teacher teacher, Student student)
        {
            if (!IsConnected())
                return;

            if (student == null || teacher == null)
                return;

            student.Teacher = teacher;
            student.TeacherUserId = teacher.UserId;
            await Task.Run(() => { 
                DBContext.UpdateObject(student); 
                Save(); 
            });
        }

        public async Task RemoveStudent(Teacher teacher, Student student)
        {
            if (!IsConnected())
                return;

            if (student == null || teacher == null)
                return;

            student.Teacher = null;
            student.TeacherUserId = null;
            await Task.Run(() =>
            {
                DBContext.UpdateObject(student);
                Save();
            });
        }

        #endregion

        #region Parent
        public async Task<Parent> GetParent(string userName)
        {
            if (!IsConnected())
                return null;

            var parent = await Task.Run(() =>
                                    (from p in DBContext.Parents
                                     where p.User.UserName == userName
                                     select p).FirstOrDefault());

            return parent;
        }

        public async Task GetStudentsByParent(string parentName, Action<IEnumerable<Student>> callback)
        {
            if (!IsConnected())
                return;

            Uri url = new Uri(String.Format("http://localhost:1103/Services/GradesWebDataService.svc/StudentsForParent?parentName='{0}'", parentName), UriKind.RelativeOrAbsolute);
            var students = await Task.Run(() => DBContext.Execute<Student>(url));

            // Invoke the callback that displays the result asynchronously
            await Task.Run(() => callback(students));
        }
        #endregion

        #region Student
        public async Task GetUnassignedStudents(Action<IEnumerable<Student>> callback)
        {
            if (!IsConnected())
                return;

            var students = await Task.Run(() => 
                                    (from s in DBContext.Students
                                     where s.TeacherUserId == null
                                     select s).OrderBy(s => s.LastName).ToList());

            await Task.Run(() => callback(students));
        }            

        public async Task<Student> GetStudent(string userName)
        {
            if (!IsConnected())
                return null;

            var student = await Task.Run(() =>
                                    (from s in DBContext.Students
                                     where s.User.UserName == userName
                                     select s).FirstOrDefault());

            return student;
        }

        public async Task<Student> GetStudent(string firstname, string lastname)
        {
            if (!IsConnected())
                return null;

            var student = await Task.Run(() =>
                                    (from s in DBContext.Students
                                     where s.FirstName == firstname && s.LastName == lastname
                                     select s).FirstOrDefault());

            return student;
        }

        public async Task<string> GetClassNameByStudent(Guid studentID)
        {
            if (!IsConnected())
                return null;

            var classname = await Task.Run(() =>
                                        (from s in DBContext.Students
                                         where s.User.UserId == studentID
                                         select s.Teacher.Class).FirstOrDefault());

            return classname;
        }

        public async Task<List<Grade>> GetGradesByStudent(Guid studentID)
        {
            if (!IsConnected())
                return null;

            var grades = await Task.Run(() =>
                                    (from g in DBContext.Grades
                                     where g.StudentUserId == studentID
                                     select g).ToList());

            return grades;
        }
        #endregion

        #region Grades
        private async void GetSubjects()
        {
            if (!IsConnected())
                return;

            // Find all the subjects in the dataservice for the current student and add them to the Subjects collection
            var subs = await Task.Run(() =>
                                    (from s in DBContext.Subjects
                                     select s).OrderBy(s => s.Name).ToList());

            Subjects = new List<Subject>();

            foreach (Subject s in subs)
                Subjects.Add(s);
        }

        public static Subject GetSubject(int id)
        {
            if (Subjects.Count == 0)
                return null;

            return Subjects.First(s => s.Id == id);
        }

        public async Task AddGrade(Grade grade)
        {
            await Task.Run(() => 
            {
                DBContext.AddToGrades(grade);
                Save();
            });
        }

        public async Task UpdateGrade(Grade grade)
        {
            if (!IsConnected())
                return;

            await Task.Run(() =>
            {
                DBContext.UpdateObject(grade);
                Save();
            });
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