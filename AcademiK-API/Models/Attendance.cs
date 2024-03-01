using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AcademiK_API.Enums;

namespace AcademiK_API.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatuses Status { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }    
        public int CourseId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Course Course { get; set; }
    }
}
