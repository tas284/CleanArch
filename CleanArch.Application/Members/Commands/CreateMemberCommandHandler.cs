using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Commands
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.BirthDate, request.Active);
            
            await _unitOfWork.MemberRepository.AddMember(member);
            await _unitOfWork.CommitAsync();

            return member;
        }
    }
}
