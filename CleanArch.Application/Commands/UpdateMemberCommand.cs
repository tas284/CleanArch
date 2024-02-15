using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class UpdateMemberCommand : MemberCommandBase
    {
        public int Id { get; set; }

        public void UpdateMember(Member member) => member.Update(FirstName, LastName, Gender, Email, BirthDate, Active);
    }
}
