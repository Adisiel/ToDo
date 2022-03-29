using Application.DTOs.CategoriaDTO;
using FluentValidation;
namespace Application.Validators.CategoriaValidators
{
    public class UpdateCategoriaDTOValidator : AbstractValidator<UpdateCategoriaDTO>
    {
        public UpdateCategoriaDTOValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage("Nome da categoria não pode ser vazio")
                .NotNull()
                    .WithMessage("Nome da categoria não pode ser nulo")
                .MaximumLength(50)
                    .WithMessage("Nome da categoria deve possuir no máximo 50 caracteres");

            RuleFor(c => c.Cor)
                .NotEmpty()
                    .WithMessage("Cor da categoria não pode ser vazia")
                .NotNull()
                    .WithMessage("Cor da categoria não pode ser nula")
                .Length(7)
                    .WithMessage("Cor da categoria deve possuir 7 caracteres")
                .Matches("^#(?:[0-9a-fA-F]{3,4}){1,2}$")
                    .WithMessage("Utilize somente o formato de cor hexadecimal");
        }
    }
}
