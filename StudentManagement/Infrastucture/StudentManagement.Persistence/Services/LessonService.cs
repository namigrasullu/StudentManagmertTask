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

public class LessonService : ILessonService
{
    private readonly IRepository<Lesson> _lessonRepository;
    private readonly IMapper _mapper;

    public LessonService(IRepository<Lesson> lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<ApiResult> AddAsync(AddLessonDto dto)
    {
        var lesson = _mapper.Map<Lesson>(dto);

        if (await _lessonRepository.AddAsync(lesson))
        {
            await _lessonRepository.SaveChangesAsync();
            return new ApiResult(
                StatusCode: StatusCodes.Status201Created,
                Message: "Lesson Created"
                );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Bad Request"
                );
    }

    public async Task<ApiResult> GetAllAsync()
    {
        var lessons = await _lessonRepository.GetAll().ToListAsync();
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(lessons)
                );
    }

    public async Task<ApiResult> GetAsync(int id)
    {
        var lesson = await _lessonRepository.GetAsync(id);
        return new ApiResult(
                StatusCode: StatusCodes.Status200OK,
                Body: JsonSerializer.Serialize(lesson)
                );
    }

    public async Task<ApiResult> RemoveAsync(int id)
    {
        if (await _lessonRepository.RemoveAsync(id))
        {
            await _lessonRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Student Deleted"
                 );
        }
        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Lesson Not Found"
                );
    }

    public async Task<ApiResult> UpdateAsync(UpdateLessonDto dto)
    {
        var lesson = _mapper.Map<Lesson>(dto);

        if (_lessonRepository.Update(lesson))
        {
            await _lessonRepository.SaveChangesAsync();
            return new ApiResult(
                 StatusCode: StatusCodes.Status200OK,
                 Message: "Lesson Updated"
                 );
        }

        return new ApiResult(
                StatusCode: StatusCodes.Status400BadRequest,
                Message: "Lesson Not Found"
                );
    }
}
