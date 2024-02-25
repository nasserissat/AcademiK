using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Models;

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
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new InvalidOperationException("Debe ingresar el nombre y el apellido del estudiante");
            }
            var studentView = new StudentView(student);
            return studentView;
        }

        public async Task<StudentView> CreateStudent(StudentData student)
        {
            if (student.FirstName == null && student.LastName == null)
                throw new InvalidOperationException("Debe ingresar el nombre y el apellido del estudiante");

            if (student.Gender == null)
                throw new InvalidOperationException("Debe ingresar un genero");

            if(student.Age < 10 || student.Age > 18)
                throw new InvalidOperationException("El sistema del colegio solo permite registrar estudiantes entre 10 a 18 años");
         
            if (student.CourseId == null)
                throw new InvalidOperationException("El estudiante debe pertenecer a un curso");
            try
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Gender = student.Gender,
                    CourseId = student.CourseId
                    
                };

                var id = await _studentRepository.CreateStudent(newStudent);
                var createdStudent = await _studentRepository.GetStudentById(id);
                var student_view = new StudentView(createdStudent);
                return student_view;

            }
            catch (Exception ex)
            {

                throw new Exception("Se produjo un error al agregar el estudiante: " + ex.Message);

            }
        }

        public async Task<StudentView> UpdateStudent(int id, StudentData studentData)
        {
            if (studentData.FirstName == null && studentData.LastName == null)
                throw new InvalidOperationException("Debe ingresar el nombre y el apellido del estudiante");           

            if (studentData.Gender == null)
                throw new InvalidOperationException("Debe ingresar un genero");
            
            if (studentData.Age < 10 || studentData.Age > 18)
                throw new InvalidOperationException("El sistema del colegio solo permite registrar estudiantes entre 10 a 18 años");

            var student = await _studentRepository.GetStudentById(id);

            if (student == null)
                throw new InvalidOperationException("El estudiante no existe ");

            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.Age = studentData.Age;
            student.Gender = studentData.Gender;
            student.CourseId = studentData.CourseId;

            await _studentRepository.UpdateStudent(student);
            var studentView = new StudentView(student);

            return studentView;
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _studentRepository.GetStudentById(id);

            if (student == null)
                throw new InvalidOperationException("El estudiante no existe ");

           await _studentRepository.DeleteStudent(student);

        }
    }
}
