using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domain.Concretes;

namespace StudentManagement.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.Property(e => e.Result).HasAnnotation("CheckConstraint", "-1 < [ClassNumber] AND [ClassNumber] < 3");
    }
}
