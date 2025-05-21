using FluentValidation;
using team3.DTOs.Category;

namespace team3.BLL.Validators.Category;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва категорії обов'язкова")
            .MaximumLength(100).WithMessage("Максимум 100 символів");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Опис не може бути довшим за 500 символів");

        RuleFor(x => x.ProductCount)
            .GreaterThanOrEqualTo(0).WithMessage("Кількість товарів не може бути від'ємною");
    }
}