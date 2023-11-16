using FluentValidation;
using ProjetoF.Application.Subscriptions.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Subscriptions.Validations;

public class CancelSubscriptionCommandValidation : AbstractValidator<CancelSubscriptionCommand>
{
    public CancelSubscriptionCommandValidation(IUnitOfWork unitOfWork)
    {
        RuleFor(s => s.StudentId)
            .MustAsync(async (s, studentId, cancellationToken) =>
            {
                return await unitOfWork.StudentRepository.ExistsAsync(studentId);
            }).WithMessage("O estudante associado ao id informado não existe");

        RuleFor(s => s.SubscriptionId)
           .MustAsync(async (s, subscriptionId, cancellationToken) =>
           {
               return await unitOfWork.SubscriptionRepository.ExistsAsync(subscriptionId);
           }).WithMessage("A assinatura associada ao id informado não existe");
    }
}
