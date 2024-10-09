namespace StudentManagement.Application.Dtos;

public record AddLessonDto(string Code, string Name, int ClassNumber, string TeacherName, string TeacherSurname, string RoomName);
