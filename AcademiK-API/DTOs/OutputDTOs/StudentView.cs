using AcademiK_API.Enums;
using AcademiK_API.Models;
using System.Security.Principal;

namespace AcademiK_API.DTOs.OutputDTOs
{
    public class StudentView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Item Course { get; set; }
        public Item Gender { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }

        public StudentView(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Course = new Item { Id = student.Course.Id , Description = student.Course?.Nivel };
            Gender = new Item { Id = (int)student.Gender, Description = student.Gender.ToString() };
            Picture = student.Picture;
            Age = student.Age;
        }
    }
}
