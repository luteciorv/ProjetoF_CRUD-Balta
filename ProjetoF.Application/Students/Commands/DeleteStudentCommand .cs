using MediatR;

namespace ProjetoF.Application.Students.Commands
{
    public class DeleteStudentCommand : IRequest
    {
        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
