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

        public Task<List<Grade>> GetAllGrades(GradeSearchData data)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grade>> SaveGrades(List<Grade> grades)
        {
            throw new NotImplementedException();
        }
    }
}

