using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler;

public class DisableStudentCommandHandler : CommandHandlerBase<DisableStudentCommand>, IRequestHandler<DisableStudentCommand>
{
    public DisableStudentCommandHandler(
        IValidator<DisableStudentCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
    ) : base(validator, publisher, notificationHandler, unitOfWork)
    { }

    public async Task Handle(DisableStudentCommand command, CancellationToken cancellationToken)
    {
        await ValidateAsync(command);
        if (ValidationFailed()) return;

        var student = await UnitOfWork.StudentRepository.GetByIdAsync(command.Id);
        student!.Delete();

        UnitOfWork.StudentRepository.Update(student);
        await UnitOfWork.SaveAsync();
    }
}
