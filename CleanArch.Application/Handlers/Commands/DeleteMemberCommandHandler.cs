using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Handlers.Commands
{
    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var deleteMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (deleteMember == null)
                throw new ArgumentNullException("Member not found.");

            await _unitOfWork.MemberRepository.DeleteMember(request.Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
