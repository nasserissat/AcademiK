using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;

namespace AcademiK_API.Logic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<StudentView>> GetAllStudents()
        {
            var students  = await _studentRepository.GetAllStudents();
            var studentViews = students.Select(student => new StudentView(student)).ToList();

            return studentViews;
        }

        public async Task<StudentView> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentView> CreateStudent(StudentData student)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentView> UpdateStudent(int id, StudentData student)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
