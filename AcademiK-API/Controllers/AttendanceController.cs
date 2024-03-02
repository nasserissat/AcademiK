using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiK_API.Logic.IServices;
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

        //[HttpGet("attendances")]
        //public Task<IActionResult> GetAllAttendances()
        //{

        //}
        
    }
}

