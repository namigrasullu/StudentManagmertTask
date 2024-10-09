using StudentManagement.Application.Dtos;
using StudentManagement.Application.Results;

namespace StudentManagement.Application.Services;

public interface IExamService
{
    Task<ApiResult> GetAllAsync();
    Task<ApiResult> GetAsync(int id);

    Task<ApiResult> AddAsync(AddExamDto dto);
    Task<ApiResult> UpdateAsync(UpdateExamDto dto);
    Task<ApiResult> RemoveAsync(int id);
}
