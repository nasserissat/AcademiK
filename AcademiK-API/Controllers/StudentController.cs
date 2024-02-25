﻿using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AcademiK_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("estudiantes")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return students.Any() ? Ok(students) : NotFound() as IActionResult;
        }

        [HttpGet("estudiante/{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                return Ok(student);

            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
        [HttpPost("crear/estudiante")]
        public async Task<ActionResult> CreateStudent([FromBody] StudentData studentData)
        {
            try
            {
                var createdStudent = await _studentService.CreateStudent(studentData);
                return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("estudiante/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentData studentData)
        {
            try
            {
                var updatedStudent = await _studentService.UpdateStudent(id, studentData);
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("estudiante/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
