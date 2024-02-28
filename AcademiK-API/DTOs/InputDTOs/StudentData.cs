using AcademiK_API.Enums;

namespace AcademiK_API.DTOs.InputDTOs
{
    public class StudentData
    {
        public string? Picture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public int CourseId { get; set; }

    }
}
