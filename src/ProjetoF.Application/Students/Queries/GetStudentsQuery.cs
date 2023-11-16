using MediatR;
using ProjetoF.Application.Students.DTOs;

namespace ProjetoF.Application.Students.Queries
{
    public class GetStudentsQuery : IRequest<IReadOnlyCollection<ReadStudentDto>>
    {
    }
}
