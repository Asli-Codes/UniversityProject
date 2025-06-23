using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.CommonEntities
{
    public class CourseDTO
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Kurs adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kurs adı en fazla 100 karakter olmalıdır.")]
        public string CourseName { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }


        [Range(1, 10, ErrorMessage = "Kredi 1 ile 10 arasında olmalıdır.")]
        public int  Credits { get; set; }


    }
}
