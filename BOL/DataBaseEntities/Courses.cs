using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.DataBaseEntities
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Credits { get; set; }


        //Kurs birden fazla öğrenciye ait olabilir
        public ICollection<CourseEntrollment> CourseEntrollments { get; set; }
    }
}
