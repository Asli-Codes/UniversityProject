using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.DataBaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataServices
{
    public class CoursesDataDAL : ICoursesDataDAL
    {
        private readonly DatabaseContext _context;

        public CoursesDataDAL(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Courses>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task AddCourseAsync(Courses course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Courses course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var courseToDelete = await _context.Courses.FindAsync(id);
            if (courseToDelete != null)
            {
                _context.Courses.Remove(courseToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
