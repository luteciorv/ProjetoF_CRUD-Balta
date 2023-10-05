﻿using MediatR;

namespace ProjetoF.Application.Students.Commands
{
    public class CreateStudentCommand : IRequest
    {
        public CreateStudentCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
