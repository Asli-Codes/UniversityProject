using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.CommonEntities
{
    public class StudentsDTO
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        [StringLength(100, ErrorMessage ="Ad en fazla 100 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Soyad en fazla 100 karakter olabilir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        
        public DateTime DateOfBirth { get; set; }

    }
}
