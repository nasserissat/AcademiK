using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AcademiK_API.DTOs.InputDTOs;

public class GradeData
{
    public int CourseId { get; set; }
    public int SubjectId { get; set; }
    public List<StudentGradeData> Students { get; set; }
}
public class StudentGradeData
{
    public int StudentId { get; set; }
    public decimal Score { get; set; }
}

