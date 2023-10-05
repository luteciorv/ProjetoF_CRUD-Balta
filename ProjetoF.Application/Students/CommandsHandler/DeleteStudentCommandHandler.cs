using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler
{
    public class DeleteStudentCommandHandler : CommandHandlerBase<DeleteStudentCommand>, IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _repository;

        public DeleteStudentCommandHandler(
            IStudentRepository repository,
            IValidator<DeleteStudentCommand> validator, 
            IPublisher publisher,
            NotificationHandler notificationHandler
        ) : base(validator, publisher, notificationHandler)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = await _repository.GetByIdAsync(command.Id);
            student!.Delete();

            _repository.Update(student);
            await _repository.SaveAsync();
        }
    }
}
