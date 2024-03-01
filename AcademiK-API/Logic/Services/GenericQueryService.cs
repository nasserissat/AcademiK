using System;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.Data.Repositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Models;

namespace AcademiK_API.Logic.Services
{
	public class GenericQueryService : IGenericQueryService
	{
        private readonly IGenericQueryRepository _genericQueryRepository;

        public GenericQueryService(IGenericQueryRepository genericQueryRepository)
        {
            _genericQueryRepository = genericQueryRepository;
        }

        public async Task<List<Item>> GetAllCourses()
        {
            var courses = await _genericQueryRepository.GetAllCourses();
            var coursesView = courses.Select(course => new Item{Id = course.Id , Description = course.Nivel }).ToList();

            return coursesView;
        }
        public async Task<List<Item>> GetAllSubjects()
        {
            var subjects = await _genericQueryRepository.GetAllSubjects();
            var subjectsView = subjects.Select(subject => new Item { Id = subject.Id, Description = subject.Name }).ToList();

            return subjectsView;
        }
    }
}

