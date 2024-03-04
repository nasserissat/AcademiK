using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Logic.IServices;
using AcademiK_API.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademiK_API.Controllers
{
    [Route("Api")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("attendances")]
        public async Task<IActionResult> GetAllAttendances([FromBody] AttendanceSearchData data)
        {
            var attendances = await _attendanceService.GetAllAttendances(data);
            return Ok(attendances);
        }
        [HttpGet("attendances/{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            try
            {
                var attendance = await _attendanceService.GetAttendanceById(id);
                return Ok(attendance);
            }catch
            {
                return NotFound();
            }
        }
        [HttpPost("attendance")]
        public async Task<IActionResult> TakeAttendance(AttendanceListData attendanceListData)
        {
            try
            {
                var studentsAttended = await _attendanceService.TakeAttendance(attendanceListData);
                if (studentsAttended.Any())
                {
                    return Created("api/Attendance/attendences", studentsAttended);
                }
                else
                {
                    return NoContent();
                }
            }
             catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("attendance/{id}")]
        public async Task<IActionResult> UpdateStudentAttendance(int id, [FromBody] AttendanceData attendanceData)
        {
            try
            {
                var attendanceUpdated = await _attendanceService.UpdateStudentAttendance(id, attendanceData);
                return Ok(attendanceUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

