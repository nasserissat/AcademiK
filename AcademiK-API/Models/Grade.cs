namespace AcademiK_API.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public decimal Score { get; set; }
        public string LetterGrade { get; set; }
        public int StudentId { get; set; }
        public int AttendanceId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
