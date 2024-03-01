
using System;
using AcademiK_API.Enums;
using AcademiK_API.Models;

namespace AcademiK_API.DTOs.OutputDTOs
{
	public class AttendanceView
	{
		public int Id { get; set; }
		public string Picture { get; set; }
		public string StudentName { get; set; }
		public Item Course { get; set; }
		public Item Subject { get; set; }
		public DateTime Date { get; set; }
		public AttendanceStatuses Status { get; set; }

		public AttendanceView(Attendance attendance)
		{
			Id = attendance.Id;
			Picture = attendance.Student.Picture;
			StudentName = attendance.Student.FirstName;
			Course = new Item { Id = attendance.CourseId, Description = attendance.Course.Nivel };
			Subject = new Item { Id = attendance.SubjectId, Description = attendance.Subject.Name };
			Date = attendance.Date;
			Status = attendance.Status;
		}
	}
}

