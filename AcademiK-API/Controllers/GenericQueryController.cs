using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Logic.IServices;
using Microsoft.AspNetCore.Mvc;


namespace AcademiK_API.Controllers
{
    [Route("api")]
    public class GenericQueryController : Controller
    {
        private readonly IGenericQueryService _genericQueryService;

        public GenericQueryController(IGenericQueryService genericQueryService)
        {
            _genericQueryService = genericQueryService;
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _genericQueryService.GetAllCourses();
            return courses.Any() ? Ok(courses) : NotFound() as IActionResult;
        }
        [HttpGet("subjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _genericQueryService.GetAllSubjects();
            return subjects.Any() ? Ok(subjects) : NotFound() as IActionResult;
        }



    }
}

