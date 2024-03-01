using System;
using AcademiK_API.Enums;

namespace AcademiK_API.DTOs.InputDTOs
{
	public class AttendanceListData
	{
		public DateTime Date{ get; set; }
		public int CourseId { get; set; }
		public int SubjectId { get; set; }
		public List<AttendandeInput> Attendances { get; set; }
	}
	public class AttendandeInput
    {
		public int StudentId { get; set; }
		public AttendanceStatuses Status { get; set; }
	}
}

