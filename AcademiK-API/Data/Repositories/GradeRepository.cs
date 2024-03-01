using System;
using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AcademiKContext _context;
        public GradeRepository(AcademiKContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> GetAllGrades(GradeSearchData data) =>
            await _context.Grades
            .Include(g => g.Course)
            .Include(g => g.Student)
            .Include(g => g.Subject)
            .where(g => data.CourseId == null || data.CourseId == g.Course.Id)
            .where(g => data.SubjectId == null || data.SubjectId == g.Subject.Id)
            .ToListAsync();

        public async Task<List<Grade>> SaveGrades(List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                _context.Grades.Add(grade);
            }
            await _context.SaveChangesAsync();
            return grades;
        }
    }
}

