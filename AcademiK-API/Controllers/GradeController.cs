using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Logic.Services;
using Microsoft.AspNetCore.Mvc;


namespace AcademiK_API.Controllers
{
    [Route("api")]
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
            return Ok(grades);
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
        [HttpDelete("grade/{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
                await _gradeService.DeleteGrade(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

