namespace AcademiK_API.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public virtual Teacher Teacher { get; set; }    
        public virtual Course Course { get; set; }
    }
}
