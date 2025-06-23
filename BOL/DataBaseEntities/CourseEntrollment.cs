using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace BOL.DataBaseEntities
{
    public class CourseEntrollment
    {
        [Key]
        public int EntrollmentId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Students Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public DateTime EntrollmentDate { get; set; }
    }
}