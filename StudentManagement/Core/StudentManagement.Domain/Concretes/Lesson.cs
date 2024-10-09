using StudentManagement.Domain.Abstracts;

namespace StudentManagement.Domain.Concretes;

public class Lesson : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int ExamId { get; set; }
    public int ClassNumber { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }
    public string RoomName { get; set; }

    public virtual ICollection<Exam>? Exams { get; set; }
}
