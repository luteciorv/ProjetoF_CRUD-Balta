using ProjetoF.Application.Students.Commands;
using ProjetoF.Application.Students.DTOs;
using ProjetoF.Domain.Entities;

namespace ProjetoF.Application.Extensions;

public static class StudentMap
{
    public static ReadStudentDto MapToReadDto(this Student entity) =>
        new(entity.Id, 
            entity.Name, 
            entity.Email, 
            $"{entity.CreatedAt.ToString("dd/MM/yyyy HH:mm")}h", 
            entity.Subscriptions.Select(s => s.MapToReadDto()).ToArray()
            );

    public static RegisterStudentCommand MapToCreateCommand(this RegisterStudentDto dto) =>
        new(dto.Name, dto.Email);

    public static EditStudentCommand MapToEditCommand(this EditStudentDto dto, Guid id) =>
        new(id, dto.Name);

    public static Student MapToEntity(this RegisterStudentCommand command) =>
        new(command.Name, command.Email);
}
