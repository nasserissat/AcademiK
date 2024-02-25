﻿using AcademiK_API.DTOs.InputDTOs;
using AcademiK_API.DTOs.OutputDTOs;
using AcademiK_API.Models;

namespace AcademiK_API.Data.IRepositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}