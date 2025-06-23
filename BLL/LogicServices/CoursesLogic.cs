using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.CommonEntities;
using BOL.DataBaseEntities;
using DAL.DataServices;

namespace BLL.LogicServices
{
    public class CoursesLogic : ICoursesLogic
    {
        private readonly ICoursesDataDAL _coursesDataDAL;

        public CoursesLogic(ICoursesDataDAL coursesDataDAL)
        {
            _coursesDataDAL = coursesDataDAL;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _coursesDataDAL.GetAllCoursesAsync();
            //veri tabanından DTO'ya dönüşüm
            return courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Description = c.Description,
                Credits = c.Credits
            }).ToList();
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await _coursesDataDAL.GetCourseByIdAsync(id);
            if (course == null)
            {
                return null;
            }
            //veri tabanından DTO'ya dönüşüm
            return new CourseDTO
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Description = course.Description,
                Credits = course.Credits
            };
        }

        public async Task AddCourseAsync(CourseDTO courseDto)
        {
            //DTOdan Veri tabanı modeline dönüşüm
            var course = new Courses
            {
                CourseName = courseDto.CourseName,
                Description = courseDto.Description,
                Credits = courseDto.Credits
            };
            await _coursesDataDAL.AddCourseAsync(course);
        }

        public async Task UpdateCourseAsync(CourseDTO courseDto)
        {
            //DTOdan Veri tabanı modeline dönüşüm
            var     existingCourse = await _coursesDataDAL.GetCourseByIdAsync(courseDto.CourseId);
            if (existingCourse != null)
           
            {
                existingCourse.CourseName = courseDto.CourseName;
                existingCourse.Description = courseDto.Description;
                existingCourse.Credits = courseDto.Credits;
                await _coursesDataDAL.UpdateCourseAsync(existingCourse);
            }
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _coursesDataDAL.DeleteCourseAsync(id);
        }

        public Task<IEnumerable<CourseDTO>> GetCoursesAsync()
        {
            throw new NotImplementedException();
        }

        Task<CourseDTO> ICoursesLogic.GetCourseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        
        
    }
}
