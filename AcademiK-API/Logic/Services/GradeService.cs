using System;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Models;

namespace AcademiK_API.Logic.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Task<List<GradeView>> GetAllGrades(GradeSearchData? data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GradeView>> RateStudents(GradeData data)
        {
            if (data.CourseId == null)
                throw new InvalidOperationException("Debe ingresar un curso");
            if (data.SubjectId == null)
                throw new InvalidOperationException("Debe ingresar una materia");
            if (data.Students == null)
                throw new InvalidOperationException("No hay estudiantes a calificar");
            foreach (var student in data.Students)
            {
                if (student.Score > 100 || student.Score < 0)
                    throw new InvalidOperationException("La nota no puede ser menor que 0 ni mayor que 100");
            }
            try
            {
                List<Grade> grades = new List<Grade>();

                foreach (var student in data.Students)
                {
                    var grade = new Grade
                    {
                        Score = student.Score,
                        LetterGrade = GetLetterGrade(student.Score),
                        SubjectId = data.SubjectId,
                        CourseId = data.CourseId,
                        StudentId = student.Id
                    };
                    grades.Add(grade);
                }
                List<GradeView> grades_view = new List<GradeView>();
                var created_grades = await _gradeRepository.SaveGrades(grades);
                foreach(var grade in created_grades)
                {
                    var grade_view = new GradeView(grade);
                    grades_view.Add(grade_view);
                }

                return grades_view;


            } catch (Exception ex)
            {
                throw new Exception("Se produjo un error al agregar las calificaciones: " + ex.Message);
            }

        }
        public string GetLetterGrade(decimal score)
        {
            if (score >= 90 && score <= 100)
            {
                return "A";
            }
            else if (score >= 80 && score <= 89)
            {
                return "B";
            }
            else if (score >= 70 && score <= 79)
            {
                return "C";
            }
            else if (score >= 0 && score <= 69)
            {
                return "F";
            }
            else
            {
                return "";
            }
        }
    }
}

