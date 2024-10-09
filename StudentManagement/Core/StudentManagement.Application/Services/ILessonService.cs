using StudentManagement.Application.Dtos;
using StudentManagement.Application.Results;

namespace StudentManagement.Application.Services;

public interface ILessonService
{
    Task<ApiResult> GetAllAsync();
    Task<ApiResult> GetAsync(int id);

    Task<ApiResult> AddAsync(AddLessonDto dto);
    Task<ApiResult> UpdateAsync(UpdateLessonDto dto);
    Task<ApiResult> RemoveAsync(int id);
}
