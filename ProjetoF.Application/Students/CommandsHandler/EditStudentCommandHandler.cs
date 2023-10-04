using FluentValidation;
using MediatR;
using ProjetoF.Application.CommandHandler;
using ProjetoF.Application.Notifications;
using ProjetoF.Application.Students.Commands;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.CommandsHandler
{
    public class EditStudentCommandHandler : CommandHandlerBase<EditStudentCommand>, IRequestHandler<EditStudentCommand>
    {
        private readonly IStudentRepository _repository;

        public EditStudentCommandHandler(
            IStudentRepository repository,
            IValidator<EditStudentCommand> validator, 
            IPublisher publisher,
            NotificationHandler notificationHandler
        ) : base(validator, publisher, notificationHandler)
        {
            _repository = repository;
        }

        public async Task Handle(EditStudentCommand command, CancellationToken cancellationToken)
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = await _repository.GetByIdAsync(command.Id);
            student!.Update(command.Name);

            _repository.Update(student);
            await _repository.SaveAsync();
        }
    }
}
