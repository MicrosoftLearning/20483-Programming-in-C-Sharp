using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;


namespace Grades.DataModel
{
    public enum Role { None, Teacher, Student };

    public partial class Teacher
    {
        public void RemoveFromClass(Student student)
        {
            // Verify that the student is actually assigned to the class for this teacher
            if (student.TeacherUserId == UserId)
            {
                // Reset the TeacherID property of the student
                student.TeacherUserId = null;
            }
            else
            {
                // If the student is not assigned to the class for this teacher, throw an ArgumentException
                throw new ArgumentException("Student", "Student is not assigned to this class");
            } 
        }
    }


    public partial class User
    {
        public bool SetPassword(Role role,string pwd)
        {
            if (role == Role.Teacher)
            {
                // Use a regular expression to check that the password contains at least two numeric characters
                Match numericMatch = Regex.Match(pwd, @".*[0-9]+.*[0-9]+.*");

                // If the password provided as the parameter is at least 8 characters long and contains at least two numeric characters then save it and return true
                if (pwd.Length >= 8 && numericMatch.Success)
                {
                    UserPassword = pwd;
                    return true;
                }
            }
            else if (role == Role.Student)
            {
                // If the password provided as the parameter is at least 6 characters long then save it and return true
                if (pwd.Length >= 6)
                {
                    UserPassword = pwd;
                    return true;
                }
            }
            // If the password is either not complex enough (Teacher) or not long enough (Teacher or Student), then do not save it and return false
            return false;
        }


        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _UserPassword) == 0);
        }
    }



    [Serializable]
    public class ClassFullException : Exception
    {
        // Custom data: the name of the class that is full
        // Code that catches this exception can query the public ClassName property to determine which class caused the exception
        private string _className;
        public virtual string ClassName
        {
            get
            {
                return _className;
            }
        }

        // Delegate functionality for the common constructors directly to the Exception class
        public ClassFullException()
        {
        }

        public ClassFullException(string message)
            : base(message)
        {
        }

        public ClassFullException(string message, Exception inner)
            : base(message, inner)
        {
        }

        // Custom constructors that populate the className field.
        // The code that invokes this exception is expected to provide the class name
        public ClassFullException(string message, string cls)
            : base(message)
        {
            _className = cls;
        }

        public ClassFullException(string message, string cls, Exception inner)
            : base(message, inner)
        {
            _className = cls;
        }

        #region Code provided to handle deserialization of a custom exception
        // Constructor for deserializing a ClassFullException object
        // The _className field contains custom data, so it must be handled explicitly
        // The details are outside the scope of this lab
        protected ClassFullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Populate the _className member from the deserialization stream 
            _className = info.GetString("ClassName");
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentException("info");
            }
            base.GetObjectData(info, context);
            info.AddValue("ClassName", _className, typeof(string));
        }
    }
#endregion
}
