using AcademiK_API.Enums;

namespace AcademiK_API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
