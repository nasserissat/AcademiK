using System;
using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Data.Repositories
{
	public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AcademiKContext _context;

        public AttendanceRepository(AcademiKContext context) 
		{
			_context = context;
		}

        public Task<List<Attendance>> GetAllAtendances(AttendanceSearchData? filter)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> GetAttendanceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Attendance>> TakeAttendances(List<Attendance> attendances)
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> UpdateStudentAttendance(Attendance attendance)
        {
            throw new NotImplementedException();
        }
    }
}

