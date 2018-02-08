using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Grades.DataModel
{
    public partial class Grade
    {
        public bool ValidateAssessmentDate(DateTime assessmentDate)
        {
            // Verify that the user has provided a valid date.
            // Check that the date is no later than the current date.
            if (assessmentDate > DateTime.Now)
            {
                // Throw an ArgumentOutOfRangeException if the date is after the current date.
                throw new ArgumentOutOfRangeException("Assessment Date", "Assessment date must be on or before the current date");
            }
            else
            {
                return true;
            }
        }

        public bool ValidateAssessmentGrade(string assessment)
        {
            // Verify that the grade is in the range A+ to E-.
            // Use a regular expression: A single character in the range A-E at the start of the string followed by an optional + or - at the end of the string.
            Match matchGrade = Regex.Match(assessment, @"^[A-E][+-]?$");
            if (!matchGrade.Success)
            {
                // If the grade is not valid, throw an ArgumentOutOfRangeException.
                throw new ArgumentOutOfRangeException("Assessment", "Assessment grade must be in the range A+ to E-");
            }
            else
            {
                return true;
            }
        }

    }
}
