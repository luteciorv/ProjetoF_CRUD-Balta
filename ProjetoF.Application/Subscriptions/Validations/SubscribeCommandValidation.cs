using FluentValidation;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.Validations;

public class SubscribeCommandValidation : AbstractValidator<SubscribeCommand>
{
    public SubscribeCommandValidation(IUnitOfWork unitOfWork)
    {
        RuleFor(s => s.Plan)
            .Must((s, plan) =>
            {
                return Enum.IsDefined(plan);
            }).WithMessage("O plano da assinatura informado não existe");

        RuleFor(s => s.StudentId)
            .MustAsync(async (s, studentId, cancellationToken) =>
            {
                return await unitOfWork.StudentRepository.GetByIdAsync(s.StudentId) is not null;
            }).WithMessage("O aluno associado ao Id informado não existe");

        RuleFor(s => s.StartDate)
            .GreaterThan(DateTime.Now).WithMessage(s => $"O campo {s.StartDate} não pode ser anterior ao dia de hoje");
    }
}
