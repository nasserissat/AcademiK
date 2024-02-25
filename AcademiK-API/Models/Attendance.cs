using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcademiK_API.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Attended { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }    

        public virtual Student Student { get; set; }
        public virtual Grade Grade { get; set; }
    }
}
