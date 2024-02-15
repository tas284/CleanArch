﻿using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class CreateMemberCommand : IRequest<Member>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public Member ToEntity() => new Member(this.FirstName, this.LastName, this.Gender, this.Email, this.BirthDate, this.Active);
    }
}
