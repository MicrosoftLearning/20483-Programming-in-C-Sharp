using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grades.Web.Models
{
    [MetadataType(typeof(GradeMetaData))]
    public partial class Grade { 

        class GradeMetaData 
        {
            [StringLength(200, ErrorMessage = "Comments cannot exceed 200 characters.")]
            public string Comments { get; set; }

            [Required]
            [RegularExpression(@"[A-E][+-]?", ErrorMessage = "An assessment must be A-E, with an optional + or -.")]
            public string Assessment { get; set; }

            [Required]
            [DisplayFormat(DataFormatString = "{0:d}")]
            public DateTime AssessmentDate { get; set; }

            [Required]
            public Guid StudentUserId { get; set; }

            [Required]
            public int SubjectId { get; set; }

        } 
    }
}