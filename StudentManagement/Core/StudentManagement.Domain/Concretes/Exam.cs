using StudentManagement.Domain.Abstracts;

namespace StudentManagement.Domain.Concretes;

public class Exam : BaseEntity
{
    public int Result { get; set; }
    public DateTime Date { get; set; }
    public int StudentId { get; set; }
    public int LessonId { get; set; }

    public virtual Student Student { get; set; }
    public virtual Lesson Lesson { get; set; }
}