﻿using System;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;

namespace AcademiK_API.Logic.IServices
{
	public interface IGradeService
	{
		Task<List<GradeView>> GetAllGrades(GradeSearchData? data);
        Task<GradeView> GetGradeById(int id);
        Task<List<GradeView>> RateStudents(GradeData data);
        Task DeleteGrade(int id);

    }
}

