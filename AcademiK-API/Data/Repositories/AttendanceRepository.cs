using System;
using AcademiK_API.Data.Context;
using AcademiK_API.Data.IRepositories;
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

        public Task<List<Attendance>> GetAllAtendances()
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> GetAttendanceById()
        {
            throw new NotImplementedException();
        }

        public Task<List<Attendance>> TakeAttendances()
        {
            throw new NotImplementedException();
        }

        public Task<Attendance> UpdateStudentAttendance()
        {
            throw new NotImplementedException();
        }
    }
}

