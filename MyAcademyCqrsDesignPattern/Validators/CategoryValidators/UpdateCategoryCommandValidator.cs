using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;

namespace MyAcademyCqrsDesignPattern.Validators.CategoryValidators
{
    public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz")
                                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakterli olabilir");

        }
    }
}
