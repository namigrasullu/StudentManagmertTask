using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Application.Dtos;
using StudentManagement.Application.Repositories;
using StudentManagement.Application.Results;
using StudentManagement.Application.Services;
using StudentManagement.Domain.Concretes;
using System.Text.Json;

namespace StudentManagement.Persistence.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IRepository<Student> studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<ApiResult> AddAsync(AddStudentDto dto)
    {
        var student = _mapper.Map<Student>(dto);

        if (await _studentRepository.AddAsync(student))
        {
            await _studentRepository.SaveChangesAsync();
            return new ApiResult(
                StatusCode: StatusCodes.Status201Created,
                Message: "Student Created"
                );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Bad Request"
                );
    }

    public async Task<ApiResult> GetAllAsync()
    {
        var students = await _studentRepository.GetAll().ToListAsync();
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(students)
                );
    }

    public async Task<ApiResult> GetAsync(int id)
    {
        var student = await _studentRepository.GetAsync(id);
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(student)
                );
    }

    public async Task<ApiResult> RemoveAsync(int id)
    {
        if (await _studentRepository.RemoveAsync(id))
        {
            await _studentRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Student Deleted"
                 );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Student Not Found"
                );
    }

    public async Task<ApiResult> UpdateAsync(UpdateStudentDto dto)
    {
        var student = _mapper.Map<Student>(dto);

        if (_studentRepository.Update(student))
        {
            await _studentRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Student Updated"
                 );
        }

        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Student Not Found"
                );
    }
}
