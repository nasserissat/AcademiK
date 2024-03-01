using System;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Logic.IServices
{
	public interface IGenericQueryService
	{
        Task<List<Item>> GetAllCourses();
        Task<List<Item>> GetAllSubjects();

    }
}

