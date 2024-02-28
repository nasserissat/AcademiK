using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;

namespace AcademiK_API.Logic.IServices
{
    public interface IStudentService
    {
        Task<List<StudentView>> GetAllStudents();
        Task<StudentView> GetStudentById(int id);
        Task<StudentView> CreateStudent(StudentData student);
        Task<StudentView> UpdateStudent(int id, StudentData student);
        Task DeleteStudent(int id);
        string GetStudentImagePath(string filename);

    }
}
