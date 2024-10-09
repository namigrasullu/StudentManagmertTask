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

public class ExamService : IExamService
{
    private readonly IRepository<Exam> _examRepository;
    private readonly IMapper _mapper;

    public ExamService(IRepository<Exam> examRepository, IMapper mapper)
    {
        _examRepository = examRepository;
        _mapper = mapper;
    }

    public async Task<ApiResult> AddAsync(AddExamDto dto)
    {
        var exam = _mapper.Map<Exam>(dto);

        if (await _examRepository.AddAsync(exam))
        {
            await _examRepository.SaveChangesAsync();
            return new ApiResult(
                StatusCode: StatusCodes.Status201Created,
                Message: "Exam Created"
                );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Bad Request"
                );
    }

    public async Task<ApiResult> GetAllAsync()
    {
        var exams = await _examRepository.GetAll().ToListAsync();
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(exams)
                );
    }

    public async Task<ApiResult> GetAsync(int id)
    {
        var exam = await _examRepository.GetAsync(id);
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(exam)
                );
    }

    public async Task<ApiResult> RemoveAsync(int id)
    {
        if (await _examRepository.RemoveAsync(id))
        {
            await _examRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Exam Deleted"
                 );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Exam Not Found"
                );
    }

    public async Task<ApiResult> UpdateAsync(UpdateExamDto dto)
    {
        var exam = _mapper.Map<Exam>(dto);

        if (_examRepository.Update(exam))
        {
            await _examRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Exam Updated"
                 );
        }

        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Exam Not Found"
                );
    }
}
