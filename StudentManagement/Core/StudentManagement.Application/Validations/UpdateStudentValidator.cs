using FluentValidation;
using StudentManagement.Application.Dtos;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentDto>
{
    public UpdateStudentValidator()
    {
        RuleFor(student => student.Number)
            .InclusiveBetween(1, 99999).WithMessage("Nömrə 1 ilə 99999 arasında olmalıdır.");

        RuleFor(student => student.Name)
            .NotEmpty().WithMessage("Ad boş ola bilməz.")
            .MaximumLength(30).WithMessage("Ad 30 simvoldan çox ola bilməz.");

        RuleFor(student => student.Surname)
            .NotEmpty().WithMessage("Soyad boş ola bilməz.")
            .MaximumLength(30).WithMessage("Soyad 30 simvoldan çox ola bilməz.");
    }
}
