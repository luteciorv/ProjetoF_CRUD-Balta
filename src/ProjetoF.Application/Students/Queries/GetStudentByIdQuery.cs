using MediatR;
using ProjetoF.Application.Students.DTOs;

namespace ProjetoF.Application.Students.Queries
{
    public class GetStudentByIdQuery : IRequest<ReadStudentDto?>
    {
        public GetStudentByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
