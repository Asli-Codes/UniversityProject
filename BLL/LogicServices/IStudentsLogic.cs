using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.CommonEntities;
using BOL.DataBaseEntities;

namespace BLL.LogicServices
{
    public interface IStudentsLogic
    {
        Task<IEnumerable<StudentsDTO>> GetStudentsAsync();
        Task<StudentsDTO> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentsDTO student);
        Task UpdateStudentAsync(StudentsDTO student);
        Task DeleteStudentAsync(int id);
    }
}
