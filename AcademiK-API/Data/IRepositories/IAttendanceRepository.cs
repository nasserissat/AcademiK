using System;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Data.IRepositories
{
	public interface IAttendanceRepository
	{
		Task<List<Attendance>> GetAllAtendances(AttendanceSearchData? filter);
		Task<Attendance> GetAttendanceById(int id);
		Task<List<Attendance>> TakeAttendances(List<Attendance> attendances);
		Task<Attendance> UpdateStudentAttendance(Attendance attendance);
	}
}
