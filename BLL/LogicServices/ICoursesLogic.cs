using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.CommonEntities;

namespace BLL.LogicServices
{
    public interface ICoursesLogic
    {
        Task<IEnumerable<CourseDTO>> GetCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task AddCourseAsync(CourseDTO courseDto);
        Task UpdateCourseAsync(CourseDTO courseDto);
        Task DeleteCourseAsync(int id);
    }
}
