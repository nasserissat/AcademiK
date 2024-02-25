using AcademiK_API.Models;
using System.Security.Principal;

namespace AcademiK_API.DTOs.OutputDTOs
{
    public class StudentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }

        public StudentView(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            CourseName = student.Course?.Nivel;
        }
    }
}
