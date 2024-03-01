using System;
using AcademiK_API.Models;

namespace AcademiK_API.Data.IRepositories
{
	public interface IGenericQueryRepository
	{
        Task<List<Course>> GetAllCourses();
        Task<List<Subject>> GetAllSubjects();
    }
}

