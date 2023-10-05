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
        private readonly IStudentRepository _repository;

        public CreateStudentCommandHandler(
            IStudentRepository studentRepository,
            IValidator<CreateStudentCommand> validator, 
            IPublisher publisher,
            NotificationHandler notificationHandler
        ) : base(validator, publisher, notificationHandler)
        {
            _repository = studentRepository;
        }

        public async Task Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            await ValidateAsync(command);
            if (ValidationFailed()) return;

            var student = command.MapToStudent();

            await _repository.AddAsync(student);
            await _repository.SaveAsync();
        }
    }
}
