using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.DataBaseEntities;


namespace DAL.DataServices
{
    public interface ICoursesDataDAL
    {
        Task<IEnumerable<Courses>> GetAllCoursesAsync();
        Task<Courses> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Courses course);
        Task UpdateCourseAsync(Courses course);
        Task DeleteCourseAsync(int id);
    }
}
