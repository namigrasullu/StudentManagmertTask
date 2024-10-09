namespace StudentManagement.Application.Dtos;
public record UpdateExamDto(int Id, int StudentId, int LessonId, DateTime Date, int Result);
