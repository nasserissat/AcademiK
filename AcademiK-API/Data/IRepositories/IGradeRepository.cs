using System;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Data.IRepositories
{
	public interface IGradeRepository
	{
		Task<List<Grade>> GetAllGrades(GradeSearchData? data);
        Task<Grade> GetGradeById(int id);
        Task<List<Grade>> SaveGrades(List<Grade> grades);
        Task DeleteGrade(Grade grade);

    }
}

