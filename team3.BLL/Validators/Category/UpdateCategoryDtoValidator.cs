using FluentValidation;
using team3.DTOs.Category;

namespace team3.BLL.Validators.Category;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        // ID обов'язкове для оновлення
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID категорії обов'язковий");

        // Повторюємо правила з Create (без Include!)
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва категорії обов'язкова")
            .MaximumLength(100).WithMessage("Максимум 100 символів");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Опис не може бути довшим за 500 символів");
    }
}