using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domain.Concretes;

namespace StudentManagement.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Number).HasAnnotation("CheckConstraint", "-1 < [Number] AND [Number] < 10000");

        builder.Property(s => s.Class).HasAnnotation("CheckConstraint", "-1 < [Number] AND [Number] < 3");

        builder.Property(s => s.Name).HasColumnType("varchar(30)");

        builder.Property(s => s.Surname).HasColumnType("varchar(30)");

        builder.HasQueryFilter(s => !s.IsDeleted);

        builder.HasMany(s => s.Exams)
            .WithOne(e => e.Student)
            .HasForeignKey(e => e.StudentId);
    }
}
