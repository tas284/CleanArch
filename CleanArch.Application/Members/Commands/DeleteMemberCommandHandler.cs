using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var deleteMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (deleteMember == null)
                throw new ArgumentNullException("Member not found.");

            var memberDelete = await _unitOfWork.MemberRepository.DeleteMember(request.Id);
            await _unitOfWork.CommitAsync();

            return deleteMember;
        }
    }
}
