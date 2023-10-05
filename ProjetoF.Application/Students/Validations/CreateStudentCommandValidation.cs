using FluentValidation;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.Validations
{
    public class CreateStudentCommandValidation : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidation(IStudentRepository repository)
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Este campo não pode ser vazio")
                .Length(3, 80).WithMessage("Este campo precisa ter entre 3 e 80 caracteres");

            RuleFor(command => command.Email)
                .EmailAddress().WithMessage("Informe um endereço de e-mail válido")
                .MustAsync(async (command, email, cancellation) =>
                {
                    return (await repository.GetByEmailAsync(email)) is null;
                }).WithMessage("O endereço informado já está em uso");
        }
    }
}
