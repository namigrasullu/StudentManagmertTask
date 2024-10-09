namespace StudentManagement.Application.Dtos;

public record UpdateLessonDto(int Id, string Code, string Name, int ClassNumber, string TeacherName, string TeacherSurname, string RoomName);

