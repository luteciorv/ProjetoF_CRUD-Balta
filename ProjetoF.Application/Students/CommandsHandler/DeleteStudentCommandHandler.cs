using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler;

public class DeleteStudentCommandHandler : CommandHandlerBase<DeleteStudentCommand>, IRequestHandler<DeleteStudentCommand>
{
    public DeleteStudentCommandHandler(
        IValidator<DeleteStudentCommand> validator,
        IPublisher publisher,
        NotificationHandler notificationHandler,
        IUnitOfWork unitOfWork
    ) : base(validator, publisher, notificationHandler, unitOfWork)
    { }

    public async Task Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        await ValidateAsync(command);
        if (ValidationFailed()) return;

        var student = await UnitOfWork.StudentRepository.GetByIdAsync(command.Id);
        student!.Delete();

        UnitOfWork.StudentRepository.Update(student);
        await UnitOfWork.SaveAsync();
    }
}
