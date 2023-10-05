using ProjetoF.Application.Students.Commands;
using ProjetoF.Application.Students.DTOs;
using ProjetoF.Domain.Entities;

namespace ProjetoF.Application.Extensions;

public static class StudentMap
{
    public static ReadStudentDto MapToReadDto(this Student entity) =>
        new(entity.Id, entity.Name, entity.Email, entity.CreatedAt.ToString("dd/MM/yyyy HH:mm"));

    public static CreateStudentCommand MapToCreateCommand(this CreateStudentDto dto) =>
        new(dto.Name, dto.Email);

    public static EditStudentCommand MapToEditCommand(this EditStudentDto dto, Guid id) =>
        new(id, dto.Name);

    public static Student MapToStudent(this CreateStudentCommand command) =>
        new(command.Name, command.Email);
}
