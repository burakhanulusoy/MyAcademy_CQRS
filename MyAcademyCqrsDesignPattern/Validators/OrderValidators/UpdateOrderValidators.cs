using FluentValidation;
using MyAcademyCqrsDesignPattern.CqrsPattern.Commands.OrderCommands;

namespace MyAcademyCqrsDesignPattern.Validators.OrderValidators
{
    public class UpdateOrderValidators:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderValidators()
        {
            RuleFor(x => x.OrderResult)
                .NotEmpty().WithMessage("Sipariş durumu boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Sipariş durumu en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Sipariş durumu en fazla 50 karakter olabilir.");


            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000000).WithMessage("Fiyat çok yüksek görünüyor.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Lütfen bir müşteri seçiniz.");
        }
    }
}
