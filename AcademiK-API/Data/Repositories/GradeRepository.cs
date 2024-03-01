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

        public async Task<List<Grade>> GetAllGrades(GradeSearchData? data)
        {
            var query = _context.Grades
                .Include(g => g.Course)
                .Include(g => g.Student)
                .Include(g => g.Subject);

            if (data?.CourseId != null && data.CourseId.Value != 0)
            {
                query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Grade, Subject>)query.Where(g => g.CourseId == data.CourseId.Value);
            }

            if (data?.SubjectId != null && data.SubjectId.Value != 0)
            {
                query = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Grade, Subject>)query.Where(g => g.SubjectId == data.SubjectId.Value);
            }

            return await query.ToListAsync();
        }



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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var grade in grades)
                    {
                        _context.Grades.Add(grade);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return grades;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task DeleteGrade(Grade grade)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

        }
    }
}

