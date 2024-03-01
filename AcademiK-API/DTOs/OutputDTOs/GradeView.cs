using System;
using AcademiK_API.Models;

namespace AcademiK_API.DTOs.OutputDTOs
{
    public class GradeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Item Course { get; set; }
        public Item Subject { get; set; }
        public string Picture { get; set; }
        public decimal Score { get; set; }
        public string LetterGrade { get; set; }

        public GradeView(Grade grade)
        {
            Id = grade.Id;
            FirstName = grade.Student.FirstName;
            LastName = grade.Student.LastName;
            Course = new Item { Id = grade.CourseId, Description = grade.Course.Nivel };
            Subject = new Item { Id = grade.SubjectId, Description = grade.Subject.Name };
            Picture = grade.Student.Picture;
            Score = grade.Score;
            LetterGrade = grade.LetterGrade;
        }
    }
}

