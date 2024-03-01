using System;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;

namespace AcademiK_API.Logic.IServices
{
	public interface IAttendanceService
	{
		Task<List<AttendanceView>> GetAllAttendances(AttendanceSearchData filter);
		Task<AttendanceView> GetAttendanceById(int id);
		Task<List<AttendanceView>> TakeAttendance(AttendanceListData data);
		Task<AttendanceView> UpdateStudentAttendance(AttendanceData data);
	}
}

