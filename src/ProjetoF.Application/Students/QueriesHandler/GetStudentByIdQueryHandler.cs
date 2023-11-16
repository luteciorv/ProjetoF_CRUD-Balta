using MediatR;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Students.DTOs;
using ProjetoF.Application.Students.Queries;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.QueriesHandler
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, ReadStudentDto?>
    {
        private readonly IStudentRepository _repository;

        public GetStudentByIdQueryHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReadStudentDto?> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByIdAsync(query.Id);
            return student?.MapToReadDto();
        }
    }
}
