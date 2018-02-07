using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GradesPrototype.Services;

namespace GradesPrototype.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // Abstract class encapsulating the common functionality for Teachers and Students
    public abstract class User
    {
        public string UserName { get; set; }

        protected string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password
        {
            set
            {
                if (!SetPassword(value))
                {
                    throw new ArgumentException("Password not complex enough", "Password");
                }
            }
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }

        // Abstract method for setting the password
        // Teachers and Students have different password complexity policies
        public abstract bool SetPassword(string pwd);
    }

    public class Grade
    {
        public int StudentID { get; set; }

        private string _assessmentDate;
        public string AssessmentDate
        {
            get
            {
                return _assessmentDate;
            }

            set
            {
                DateTime assessmentDate;

                // Verify that the user has provided a valid date
                if (DateTime.TryParse(value, out assessmentDate))
                {
                    // Check that the date is no later than the current date.                    
                    if (assessmentDate > DateTime.Now)
                    {
                        // Throw an ArgumentOutOfRangeException if the date is after the current date
                        throw new ArgumentOutOfRangeException("AssessmentDate", "Assessment date must be on or before the current date");
                    }

                    // If the date is valid, then save it in the appropriate format.
                    _assessmentDate = assessmentDate.ToString("d");
                }
                else
                {
                    // If the date is not in a valid format then throw an ArgumentException
                    throw new ArgumentException("AssessmentDate", "Assessment date is not recognized");
                }
            }
        }

        private string _subjectName;
        public string SubjectName
        {
            get
            {
                return _subjectName;
            }

            set 
            { 
                // Check that the specified subject is valid
                if (DataSource.Subjects.Contains(value))
                {
                    // If the subject is valid store the subject name 
                    _subjectName = value;
                }
                else
                {
                    // If the subject is not valid then throw an ArgumentException
                    throw new ArgumentException("Subject", "Subject is not recognized");
                }
            }
        }

        private string _assessment;
        public string Assessment
        {
            get
            {
                return _assessment;
            }

            set
            {
                // Verify that the grade is in the range A+ to E-
                // Use a regular expression: A single character in the range A-E at the start of the string followed by an optional + or - at the end of the string
                Match matchGrade = Regex.Match(value, @"^[A-E][+-]?$");
                if (matchGrade.Success)
                {
                    _assessment = value;
                }
                else
                {
                    // If the grade is not valid then throw an ArgumentOutOfRangeException
                    throw new ArgumentOutOfRangeException("Assessment", "Assessment grade must be in the range A+ to E-");;
                }
            }
        }

        public string Comments { get; set; }
                
        // Constructor to initialize the properties of a new Grade
        public Grade(int studentID, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentID = studentID;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }

        // Default constructor
        public Grade()
        {
            StudentID = 0;
            AssessmentDate = DateTime.Now.ToString("d");
            SubjectName = "Math";
            Assessment = "A";
            Comments = String.Empty;
        }
    }

    public class Student: User, IComparable<Student>
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize the properties of a new Student
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }

        // Default constructor 
        public Student()
        {
            StudentID = 0;
            UserName = String.Empty;
            Password = Guid.NewGuid().ToString();
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }

        // Compare Student objects based on their LastName and FirstName properties
        public int CompareTo(Student other)
        {
            // Concatenate the LastName and FirstName of this student
            string thisStudentsFullName = LastName + FirstName;

            // Concatenate the LastName and FirstName of the "other" student
            string otherStudentsFullName = other.LastName + other.FirstName;

            // Use String.Compare to compare the concatenated names and return the result
            return(String.Compare(thisStudentsFullName, otherStudentsFullName));
        }

        // Add a grade to a student (the grade is already populated)
        public void AddGrade(Grade grade)
        {
            // Verify that the grade does not belong to another student - the StudentID should be zero
            if (grade.StudentID == 0)
            {
                // Add the grade to the student's record
                grade.StudentID = StudentID;
            }
            else
            {
                // If the grade belongs to a different student, throw an ArgumentException
                throw new ArgumentException("Grade", "Grade belongs to a different student");
            }   
        }

        // Set the password for the student
        // The password policy is very simple - the password must be at least 6 characters long, but there are no other restrictions
        public override bool SetPassword(string pwd)
        {
            // If the password provided as the parameter is at least 6 characters long then save it and return true
            if (pwd.Length >= 6)
            {
                _password = pwd;
                return true;
            }
            // If the password is not long enough, then do not save it and return false
            return false;
        }
    }

    public class Teacher : User
    {
        // The maximum class size for any teacher
        private const int MAX_CLASS_SIZE = 8;

        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        // Constructor to initialize the properties of a new Teacher
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        // Default constructor
        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = Guid.NewGuid().ToString();
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }

        // Enroll a student in the class for this teacher
        public void EnrollInClass(Student student)
        {
            // Verify that this teacher's class is not already full

            // Determine how many students are currently in the class
            int numStudents = (from s in DataSource.Students
                               where s.TeacherID == TeacherID
                               select s).Count();

            // If the class is already full, then another student cannot be enrolled
            if (numStudents == MAX_CLASS_SIZE)
            {
                // So throw a ClassFullException and specify the class that is full
                throw new ClassFullException("Class full: Unable to enroll student", Class);
            }

            // Verify that the student is not already enrolled in another class
            if (student.TeacherID == 0)
            {
                // Set the TeacherID property of the student
                student.TeacherID = TeacherID;
            }
            else
            {
                // If the student is already assigned to a class, throw an ArgumentException
                throw new ArgumentException("Student", "Student is already assigned to a class");
            }            
        }

        // Remove a student from the class for this teacher
        public void RemoveFromClass(Student student)
        {
            // Verify that the student is actually assigned to the class for this teacher
            if (student.TeacherID == TeacherID)
            {
                // Reset the TeacherID property of the student
                student.TeacherID = 0;
            }
            else
            {
                // If the student is not assigned to the class for this teacher, throw an ArgumentException
                throw new ArgumentException("Student", "Student is not assigned to this class");
            } 
        }

        // Set the password for the teacher
        // The password must be at least 8 characters long, and it must contain at least 2 numeric characters
        public override bool SetPassword(string pwd)
        {
            // Use a regular expression to check that the password contains at least two numeric characters
            Match numericMatch = Regex.Match(pwd, @".*[0-9]+.*[0-9]+.*");

            // If the password provided as the parameter is at least 8 characters long and contains at least two numeric characters then save it and return true
            if (pwd.Length >= 8 && numericMatch.Success)
            {
                _password = pwd;
                return true;
            }
            // If the password is not complex enough, then do not save it and return false
            return false;
        }
    }
}
