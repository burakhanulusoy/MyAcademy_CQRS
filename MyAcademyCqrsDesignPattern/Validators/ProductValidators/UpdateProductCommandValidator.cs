using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.ProductCommands;

namespace MyAcademyCqrsDesignPattern.Validators.ProductValidators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz.")
                .MinimumLength(10).WithMessage("Ürün açıklaması en az 10 karakter olmalıdır.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Ürün görseli (URL) boş bırakılamaz.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");
        }
    }
}