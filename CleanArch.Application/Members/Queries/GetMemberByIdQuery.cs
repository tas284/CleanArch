using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Queries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public int Id { get; set; }
    }
}
