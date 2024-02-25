namespace AcademiK_API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string  Nivel { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
