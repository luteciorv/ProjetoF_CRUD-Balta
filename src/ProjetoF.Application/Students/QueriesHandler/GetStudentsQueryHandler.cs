using MediatR;
using ProjetoF.Application.Extensions;
using ProjetoF.Application.Students.DTOs;
using ProjetoF.Application.Students.Queries;
using ProjetoF.Domain.Interfaces.Repositories;

namespace ProjetoF.Application.Students.QueriesHandler
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IReadOnlyCollection<ReadStudentDto>>
    {
        private readonly IStudentRepository _repository;

        public GetStudentsQueryHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<ReadStudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _repository.GetAllAsync();
            if (!students.Any()) return Array.Empty<ReadStudentDto>();

            return students.Select(s => s.MapToReadDto()).ToArray();
        }
    }
}
