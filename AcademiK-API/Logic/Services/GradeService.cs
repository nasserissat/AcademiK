using System;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;

namespace AcademiK_API.Logic.Services
{
	public class GradeService : IGradeService
	{
		private readonly IGradeRepository _gradeRepository;

		public GradeService(IGradeRepository gradeRepository )
		{
			_gradeRepository = gradeRepository;
		}

        public Task<List<GradeView>> GetAllGrades(GradeSearchData? data)
        {
            throw new NotImplementedException();
        }

        public Task<List<GradeView>> RateStudents(GradeData data)
        {
            throw new NotImplementedException();
        }
    }
}

