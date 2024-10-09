using StudentManagement.Application.Dtos;
using StudentManagement.Application.Results;

namespace StudentManagement.Application.Services;

public interface IStudentService
{
    Task<ApiResult> GetAllAsync();
    Task<ApiResult> GetAsync(int id);

    Task<ApiResult> AddAsync(AddStudentDto dto);
    Task<ApiResult> UpdateAsync(UpdateStudentDto dto);
    Task<ApiResult> RemoveAsync(int id);
}
