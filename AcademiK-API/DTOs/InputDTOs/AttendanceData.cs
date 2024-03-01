using System;
using AcademiK_API.Enums;
using AcademiK_API.Models;

namespace AcademiK_API.DTOs.InputDTOs
{
	public class AttendanceData
	{
		public AttendanceStatuses Status { get; set; }

        public AttendanceData(Attendance attendance)
        {
            Status = attendance.Status;
        }
	}
}

