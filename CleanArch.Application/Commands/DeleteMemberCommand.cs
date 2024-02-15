using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class DeleteMemberCommand : IRequest
    {
        public int Id { get; set; }
    }
}
