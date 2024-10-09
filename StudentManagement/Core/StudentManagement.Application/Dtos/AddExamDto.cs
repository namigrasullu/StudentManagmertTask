namespace StudentManagement.Application.Dtos;

public record AddExamDto(int StudentId, int LessonId, DateTime Date, int Result);
