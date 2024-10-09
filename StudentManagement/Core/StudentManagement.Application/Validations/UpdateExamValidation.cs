using FluentValidation;
using StudentManagement.Application.Dtos;

namespace StudentManagement.Application.Validations;

public class UpdateExamValidator : AbstractValidator<UpdateExamDto>
{
    public UpdateExamValidator()
    {
        RuleFor(exam => exam.StudentId)
            .GreaterThan(0).WithMessage("StudentId düzgün olmalıdır.");

        RuleFor(exam => exam.LessonId)
            .GreaterThan(0).WithMessage("LessonId düzgün olmalıdır.");

        RuleFor(exam => exam.Date)
            .NotEmpty().WithMessage("İmtahan tarixi boş ola bilməz.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("İmtahan tarixi gələcəkdə ola bilməz.");

        RuleFor(exam => exam.Result)
            .InclusiveBetween(0, 9).WithMessage("Qiymət 0 ilə 9 arasında olmalıdır.");
    }
}