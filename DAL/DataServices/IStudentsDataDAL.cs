using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.DataBaseEntities;

namespace DAL.DataServices
{
    public interface IStudentsDataDAL
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Students student);
        Task UpdateStudentAsync(Students student);
        Task DeleteStudentAsync(int id);
    }
}
