using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler;

public class EditStudentCommandHandler : CommandHandlerBase<EditStudentCommand>, IRequestHandler<EditStudentCommand>
{
    public EditStudentCommandHandler(
        IValidator<EditStudentCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
    ) : base(validator, publisher, notificationHandler, unitOfWork)
    { }

    public async Task Handle(EditStudentCommand command, CancellationToken cancellationToken)
    {
        await ValidateAsync(command);
        if (ValidationFailed()) return;

        var student = await UnitOfWork.StudentRepository.GetByIdAsync(command.Id);
        student!.Update(command.Name);

        UnitOfWork.StudentRepository.Update(student);
        await UnitOfWork.SaveAsync();
    }
}
