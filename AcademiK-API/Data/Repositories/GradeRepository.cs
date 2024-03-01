using System;
using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiK_API.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AcademiKContext _context;
        public GradeRepository(AcademiKContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> GetAllGrades(GradeSearchData? data) =>
            await _context.Grades
            .Include(g => g.Course)
            .Include(g => g.Student)
            .Include(g => g.Subject)
            .Where(g => data.CourseId == 0 || data.CourseId == g.Course.Id)
            .Where(g => data.SubjectId == 0 || data.SubjectId == g.Subject.Id)
            .ToListAsync();

        public async Task<Grade> GetGradeById(int id)
        {
            return await _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Grade>> SaveGrades(List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                _context.Grades.Add(grade);
            }
            await _context.SaveChangesAsync();
            return grades;
        }
        public async Task DeleteGrade(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

        }
    }
}

