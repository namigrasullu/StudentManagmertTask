using FluentValidation;
using StudentManagement.Application.Dtos;

namespace StudentManagement.Application.Validations;

public class AddLessonValidator : AbstractValidator<AddLessonDto>
{
    public AddLessonValidator()
    {
        RuleFor(lesson => lesson.Code)
            .NotEmpty().WithMessage("Dərsin kodu boş ola bilməz.")
            .Length(3).WithMessage("Dərsin kodu 3 simvoldan ibarət olmalıdır.");

        RuleFor(lesson => lesson.Name)
            .NotEmpty().WithMessage("Dərsin adı boş ola bilməz.")
            .MaximumLength(30).WithMessage("Dərsin adı 30 simvoldan çox ola bilməz.");

        RuleFor(lesson => lesson.ClassNumber)
            .InclusiveBetween(1, 99).WithMessage("Sinif nömrəsi 1 ilə 99 arasında olmalıdır.");

        RuleFor(lesson => lesson.TeacherName)
            .NotEmpty().WithMessage("Müəllimin adı boş ola bilməz.")
            .MaximumLength(20).WithMessage("Müəllimin adı 20 simvoldan çox ola bilməz.");

        RuleFor(lesson => lesson.TeacherSurname)
            .NotEmpty().WithMessage("Müəllimin soyadı boş ola bilməz.")
            .MaximumLength(20).WithMessage("Müəllimin soyadı 20 simvoldan çox ola bilməz.");

    }
}