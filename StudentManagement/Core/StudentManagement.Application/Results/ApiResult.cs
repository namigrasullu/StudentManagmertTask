namespace StudentManagement.Application.Results;

public record ApiResult(int StatusCode, string? Message = null, string? Body = null);