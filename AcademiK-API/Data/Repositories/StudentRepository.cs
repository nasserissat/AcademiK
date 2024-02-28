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
        private readonly ILogger _logger;

        public StudentRepository(AcademiKContext context, ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<int> CreateStudent(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

        }
    }
}
