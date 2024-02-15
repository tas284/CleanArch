using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class CreateMemberCommand : MemberCommandBase
    {
        public Member ToEntity() => new Member(this.FirstName!, this.LastName!, this.Gender!, this.Email!, this.BirthDate, this.Active);
    }
}
