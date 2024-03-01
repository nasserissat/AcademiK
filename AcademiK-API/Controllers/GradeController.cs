using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Logic.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcademiK_API.Controllers
{
    [Route("api/[controller]")]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet("grades")]
        public async Task<IActionResult> GetAllGrades([FromQuery] GradeSearchData? filter)
        {
            var grades = await _gradeService.GetAllGrades(filter);
            return grades.Any() ? Ok(grades) : NotFound() as IActionResult;
        }

       
        [HttpPost("grade/add")]
        public async Task<ActionResult> RateStudents([FromBody] GradeData gradeData)
        {
            try
            {
                var addedGrades = await _gradeService.RateStudents(gradeData);
                if (addedGrades.Any())
                {
                    return Created("api/Grade/grades", addedGrades);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

