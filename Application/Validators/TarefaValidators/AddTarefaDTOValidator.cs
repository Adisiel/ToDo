using Application.DTOs.TarefaDTO;
using FluentValidation;

namespace Application.Validators.TarefaValidators
{
    public class AddTarefaDTOValidator : AbstractValidator<AddTarefaDTO>
    {
        public AddTarefaDTOValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty()
                    .WithMessage("Título da tarefa não pode ser vazio.")
                .NotNull()
                    .WithMessage("Título da tarefa não pode ser nulo.")
                .MaximumLength(40)
                    .WithMessage("Título da tarefa deve possuir no máximo 40 caracteres.");

            RuleFor(t => t.Descricao)
                .NotEmpty()
                    .WithMessage("Descrição da tarefa não pode ser vazia.")
                .NotNull()
                    .WithMessage("Descrição da tarefa não pode ser nula.")
                .MaximumLength(100)
                    .WithMessage("Descrição da tarefa deve possuir no máximo 100 caracteres.");

            RuleFor(t => t.Prioridade)
                .NotEmpty()
                    .WithMessage("Prioridade da tarefa não pode ser vazia.")
                .NotNull()
                    .WithMessage("Prioridade da tarefa não pode ser nula.");

            RuleFor(t => t.DataEntrega)
                .NotEmpty()
                    .WithMessage("Data de Entrega da tarefa não pode ser vazia.")
                .NotNull()
                    .WithMessage("Data de Entrega da tarefa não pode ser nula.")
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                    .WithMessage("Data de entrega não pode ser menor que o dia atual.");

            RuleFor(t => t.CategoriaId)
                .NotEmpty()
                    .WithMessage("Categoria da tarefa não pode ser vazia.")
                .NotNull()
                    .WithMessage("Categoria da tarefa não pode ser nula.");
        }
    }
}
