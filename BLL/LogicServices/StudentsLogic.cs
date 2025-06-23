using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.CommonEntities;
using BOL.DataBaseEntities;
using DAL.DataServices;
using BLL.LogicServices;

namespace BLL.LogicServices
{
    public class StudentsLogic : IStudentsLogic
    {
        private readonly IStudentsDataDAL _studentsDataDAL;

        public StudentsLogic(IStudentsDataDAL studentsDataDAL)
        {
            _studentsDataDAL = studentsDataDAL;
        }

        public async Task<IEnumerable<StudentsDTO>> GetAllStudentsAsync()
        {
            var students = await _studentsDataDAL.GetAllStudentsAsync();

            //veri tabanından DTO'ya dönüşüm

            return students.Select(s => new StudentsDTO
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                DateOfBirth = s.DateOfBirth
            }).ToList();
        }

        public async Task<StudentsDTO> GetStudentByIdAsync(int id)
        {
            var student = await _studentsDataDAL.GetStudentByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            //veri tabanından DTO'ya dönüşüm
            return new StudentsDTO
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth
            };
        }

        public async Task AddStudentAsync(StudentsDTO studentDto)
        {
            //DTOdan Veri tabanı modeline dönüşüm
            var student = new Students
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                DateOfBirth = studentDto.DateOfBirth
            };
            await _studentsDataDAL.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(StudentsDTO studentDto)
        {
            //DTOdan Veri tabanı modeline dönüşüm
            var existingStudent = await _studentsDataDAL.GetStudentByIdAsync(studentDto.StudentId);
            {
                existingStudent.FirstName = studentDto.FirstName;
                existingStudent.LastName = studentDto.LastName;
                existingStudent.Email = studentDto.Email;
                existingStudent.DateOfBirth = studentDto.DateOfBirth;
                await _studentsDataDAL.UpdateStudentAsync(existingStudent);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            // Hata yönetimi (öğrenci bulunamazsa ne olcak) buraya eklenebilir
            await _studentsDataDAL.DeleteStudentAsync(id);
        }

        public Task<IEnumerable<StudentsDTO>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
