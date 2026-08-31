using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.CustomerCommands;

namespace MyAcademyCqrsDesignPattern.Validators.CustomerValidators
{
    public class UpdateCustomerValidator:AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Id)
                  .GreaterThan(0).WithMessage("Geçersiz müşteri Id değeri.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad soyad alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Ad soyad en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.")
                .MaximumLength(30).WithMessage("Şehir en fazla 30 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                .Matches(@"^0?5\d{9}$")
                .WithMessage("Telefon numarası geçerli formatta değil. Örnek: 05321234567");



        }



    }
}
