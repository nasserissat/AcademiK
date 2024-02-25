using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcademiK_API.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name{ get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public virtual Teacher Teacher { get; set; }    
        public virtual Course Course { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
