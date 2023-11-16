using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler
{
    public class RegisterStudentCommandHandler : CommandHandlerBase<RegisterStudentCommand>, IRequestHandler<RegisterStudentCommand>
    {
        public RegisterStudentCommandHandler(
            IValidator<RegisterStudentCommand> validator,
            IPublisher publisher,
            NotificationHandler notificationHandler,
            IUnitOfWork unitOfWork
        ) : base(validator, publisher, notificationHandler, unitOfWork)
        { }

        public async Task Handle(RegisterStudentCommand command, CancellationToken cancellationToken)
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = command.MapToEntity();

            await UnitOfWork.StudentRepository.AddAsync(student);
            await UnitOfWork.SaveAsync();
        }
    }
}
