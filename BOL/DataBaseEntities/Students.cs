using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.DataBaseEntities
{
    public class Students
    {
        [Key] //Anahtar alanı
        public int StudentId { get; set; }

        [Required] //Alanın boş bırakılmayacağını belirtir.
        [MaxLength(100)] //Max karakter uzunluğu için 
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress] //Geçerli bir e-posta adresi formatı için 
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<CourseEntrollment> courseEntrollments { get; set; }
    }
}
