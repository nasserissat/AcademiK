namespace AcademiK_API.DTOs.InputDTOs;

public class GradeData
{
    public int CourseId { get; set; }
    public int SubjectId { get; set; }
    public List<StudentGradeData> Students { get; set; }
}
public class StudentGradeData
{
    public int Id { get; set; }
    public decimal Score { get; set; }
}

