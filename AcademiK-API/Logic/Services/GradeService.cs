﻿using System;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.Data.Repositories;
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

        public async Task<List<GradeView>> GetAllGrades(GradeSearchData? filter)
        {
            try
            {
                var grades = await _gradeRepository.GetAllGrades(filter);
                return grades.Select(g => new GradeView(g)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error al recuperar las calificaciones: " + ex.Message);
            }
        }
        public async Task<GradeView> GetGradeById(int id)
        {
            var grade = await _gradeRepository.GetGradeById(id);
            if (grade == null)
            {
                throw new InvalidOperationException("No se encontró la calificación");
            }
            var gradeView = new GradeView(grade);
            return gradeView;
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
                await _gradeRepository.SaveGrades(grades);
                GradeSearchData filter = new GradeSearchData { CourseId = 0, SubjectId = 0 };
                var all_grades = await _gradeRepository.GetAllGrades(filter);
                foreach(var grade in all_grades)
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
        public async Task DeleteGrade(int id)
        {
            var grade = await _gradeRepository.GetGradeById(id);

            if (grade == null)
                throw new InvalidOperationException("La calificación no existe ");

            await _gradeRepository.DeleteGrade(grade);

        }
    }
}

