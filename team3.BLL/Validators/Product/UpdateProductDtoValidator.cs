using FluentValidation;
using team3.DTOs.Product;

namespace team3.BLL.Validators.Product;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        // ID обов'язкове для оновлення
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID продукту обов'язковий");

        // Повторюємо правила з Create
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва продукту обов'язкова")
            .MaximumLength(100).WithMessage("Максимум 100 символів");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Ціна має бути більшою за 0");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Кількість не може бути від'ємною");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Категорія обов'язкова");
    }
}