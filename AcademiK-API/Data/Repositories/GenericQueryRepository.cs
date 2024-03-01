using System;
using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiK_API.Data.Repositories
{
	public class GenericQueryRepository : IGenericQueryRepository
	{
        private readonly AcademiKContext _context;

        public GenericQueryRepository(AcademiKContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllCourses() =>
           await _context.Courses
           .ToListAsync();

        public async Task<List<Subject>> GetAllSubjects() =>
           await _context.Subjects
           .ToListAsync();
    }
}

