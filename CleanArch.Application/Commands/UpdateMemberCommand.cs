using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class UpdateMemberCommand : MemberCommandBase
    {
        public int Id { get; set; }

        public void UpdateMember(Member member)
        {
            member.FirstName = FirstName;
            member.LastName = LastName;
            member.Gender = Gender;
            member.Email = Email;
            member.BirthDate = BirthDate;
            member.Active = Active;
        }
    }
}
