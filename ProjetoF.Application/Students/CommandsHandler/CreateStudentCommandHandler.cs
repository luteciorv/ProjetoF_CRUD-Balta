using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler
{
    public class CreateStudentCommandHandler : CommandHandlerBase<CreateStudentCommand>, IRequestHandler<CreateStudentCommand>
    {
        public CreateStudentCommandHandler(
            IValidator<CreateStudentCommand> validator,
            IPublisher publisher,
            NotificationHandler notificationHandler,
            IUnitOfWork unitOfWork
        ) : base(validator, publisher, notificationHandler, unitOfWork)
        { }

        public async Task Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = command.MapToStudent();

            await UnitOfWork.StudentRepository.AddAsync(student);
            await UnitOfWork.SaveAsync();
        }
    }
}
