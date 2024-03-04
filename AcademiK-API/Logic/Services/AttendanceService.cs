
using System;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Logic.IServices;

namespace AcademiK_API.Logic.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IAttendanceRepository _attendanceRepository;
		public AttendanceService(IAttendanceRepository attendanceRepository)
		{
            _attendanceRepository = attendanceRepository;
		}

        public Task<List<AttendanceView>> GetAllAttendances(AttendanceSearchData? filter)
        {
            throw new NotImplementedException();
        }

        public Task<AttendanceView> GetAttendanceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttendanceView>> TakeAttendance(AttendanceListData data)
        {
            throw new NotImplementedException();
        }

        public Task<AttendanceView> UpdateStudentAttendance(int id, AttendanceData data)
        {
            throw new NotImplementedException();
        }
    }
}

