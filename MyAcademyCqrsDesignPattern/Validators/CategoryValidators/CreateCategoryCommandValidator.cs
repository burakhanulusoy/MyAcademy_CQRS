using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CategoryCommands;

namespace MyAcademyCqrsDesignPattern.Validators.CategoryValidators
{
    public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz");

        }

    }
}
