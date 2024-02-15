using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class UpdateMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public void UpdateToMember(Member member)
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
