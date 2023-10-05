using MediatR;

namespace ProjetoF.Application.Students.Commands
{
    public class EditStudentCommand : IRequest
    {
        public EditStudentCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
