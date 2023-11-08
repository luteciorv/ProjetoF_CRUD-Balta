using FluentValidation;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.Validations;

public class DisableStudentCommandValidation : AbstractValidator<DisableStudentCommand>
{
    public DisableStudentCommandValidation(IStudentRepository repository)
    {
        RuleFor(command => command.Id)
            .MustAsync(async (command, id, cancellation) =>
            {
                return await repository.GetByIdAsync(id) is not null;
            }).WithMessage("O usuário informado não existe");
    }
}
