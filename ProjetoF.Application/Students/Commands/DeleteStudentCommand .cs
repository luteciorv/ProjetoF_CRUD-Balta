using MediatR;

namespace ProjetoF.Application.Students.Commands;

public class DisableStudentCommand : IRequest
{
    public DisableStudentCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
