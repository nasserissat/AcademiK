using AcademiK_API.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcademiK_API.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public int Age {  get; set; }
        public int CourseId { get; set; }
        public string Picture { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Grade> Grades { get;}
        public virtual ICollection<Attendance> Attendances { get; }

    }
}
