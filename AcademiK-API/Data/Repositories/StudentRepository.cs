using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiK_API.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AcademiKContext _context;
        public StudentRepository(AcademiKContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
