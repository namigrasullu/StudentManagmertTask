using StudentManagement.Domain.Abstracts;

namespace StudentManagement.Domain.Concretes;

public class Student : BaseEntity
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Class { get; set; }

    public virtual ICollection<Exam>? Exams { get; set; }
}