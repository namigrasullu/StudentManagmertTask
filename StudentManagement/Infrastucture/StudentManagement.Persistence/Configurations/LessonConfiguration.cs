using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domain.Concretes;

namespace StudentManagement.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(l => l.Code).HasColumnType("char(3)");

        builder.Property(l => l.Name).HasColumnType("varchar(30)");

        builder.Property(l => l.ClassNumber).HasAnnotation("CheckConstraint", "-1 < [ClassNumber] AND [ClassNumber] < 3");

        builder.Property(l => l.TeacherName).HasColumnType("varchar(20)");

        builder.Property(l => l.TeacherSurname).HasColumnType("varchar(20)");

        builder.HasQueryFilter(l => !l.IsDeleted);

        builder.HasMany(l => l.Exams)
               .WithOne(e => e.Lesson)
               .HasForeignKey(e => e.LessonId);
    }
}
