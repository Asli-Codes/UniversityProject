using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.DataBaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataServices
{
    public class StudentsDataDAL : IStudentsDataDAL
    {
        private readonly DatabaseContext _context;

        public StudentsDataDAL(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Students students)
        {
            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Students students)
        {
            _context.Students.Update(students);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
