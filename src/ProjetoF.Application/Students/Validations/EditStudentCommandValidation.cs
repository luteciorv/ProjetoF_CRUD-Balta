using FluentValidation;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.Validations;

public class EditStudentCommandValidation : AbstractValidator<EditStudentCommand>
{
    public EditStudentCommandValidation(IStudentRepository repository)
    {
        RuleFor(command => command.Id)
            .MustAsync(async (command, id, cancellation) =>
            {
                return await repository.GetByIdAsync(id) is not null;
            }).WithMessage("O usuário informado não existe");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Este campo não pode ser vazio")
            .Length(3, 80).WithMessage("Este campo precisa ter entre 3 e 80 caracteres");
    }
}
