using FluentValidation;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.Validations;

public class SubscribeCommandValidation : AbstractValidator<SubscribeCommand>
{
    public SubscribeCommandValidation(IUnitOfWork unitOfWork)
    {
        RuleFor(s => s.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(s => $"O campo {nameof(s.Title)} não pode ser vazio")
            .Length(3, 25).WithMessage(s => $"O campo {nameof(s.Title)} precisa contar de 3 a 25 caracteres");

        RuleFor(s => s.StudentId)
            .MustAsync(async (s, studentId, cancellationToken) =>
            {
                return await unitOfWork.StudentRepository.GetByIdAsync(s.StudentId) is not null;
            }).WithMessage("O aluno associado ao Id informado não existe");

        RuleFor(s => s.StartDate)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(DateTime.Now).WithMessage(s => $"O campo {s.StartDate} não pode ser anterior ao dia de hoje")
            .LessThan(s => s.EndDate).WithMessage(s => $"O campo {s.StartDate} não pode ser depois do campo {s.EndDate}");

        RuleFor(s => s.EndDate)
            .GreaterThan(s => s.StartDate).WithMessage(s => $"O campo {s.EndDate} não pode ser anterior campo {s.StartDate}");
    }
}
