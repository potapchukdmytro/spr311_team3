using FluentValidation;
using team3.DTOs.Category;

namespace team3.BLL.Validators.Category;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва категорії обов'язкова")
            .MaximumLength(100).WithMessage("Максимум 100 символів");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Опис не може бути довшим за 500 символів");
    }
}