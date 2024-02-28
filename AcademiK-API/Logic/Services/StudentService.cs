using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Enums;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Models;

namespace AcademiK_API.Logic.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _env;

        public StudentService(IStudentRepository studentRepository, IWebHostEnvironment env)
        {
            _studentRepository = studentRepository;
            _env = env;

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

            if (student.GenderId == null)
                throw new InvalidOperationException("Debe ingresar un genero");

            if (student.Age < 10 || student.Age > 18)
                throw new InvalidOperationException("El sistema del colegio solo permite registrar estudiantes entre 10 a 18 años");

            if (student.CourseId == null)
                throw new InvalidOperationException("El estudiante debe pertenecer a un curso");

            // Procesar img del usuario
            string filePath = string.Empty;

            try
            {
                string base64Image = student.Picture;
                if (base64Image.Contains(","))
                {
                    base64Image = base64Image.Split(',')[1];
                }

                byte[] imageBytes = Convert.FromBase64String(base64Image);
                filePath = Utilities.ReusableMehtods.SaveImage(imageBytes, student.FirstName, student.LastName);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al procesar la imagen del estudiante: " + ex.Message);
            }

            // Agregar estudiante
            try
            {
                var newStudent = new Student
                {
                    Picture = filePath,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Gender = (GenderEnum)student.GenderId,
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

            if (studentData.GenderId == null)
                throw new InvalidOperationException("Debe ingresar un genero");
            
            if (studentData.Age < 10 || studentData.Age > 18)
                throw new InvalidOperationException("El sistema del colegio solo permite registrar estudiantes entre 10 a 18 años");

            var student = await _studentRepository.GetStudentById(id);

            if (student == null)
                throw new InvalidOperationException("El estudiante no existe ");

            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.Age = studentData.Age;
            student.Gender = (GenderEnum)studentData.GenderId;
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
