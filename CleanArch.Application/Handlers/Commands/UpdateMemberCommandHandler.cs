using CleanArch.Application.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Handlers.Commands
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var updateMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (updateMember == null)
                throw new ArgumentException("Member not found.");

            updateMember.FirstName = request.FirstName;
            updateMember.LastName = request.LastName;
            updateMember.Gender = request.Gender;
            updateMember.Email = request.Email;
            updateMember.BirthDate = request.BirthDate;
            updateMember.Active = request.Active;

            _unitOfWork.MemberRepository.UpdateMember(updateMember);
            await _unitOfWork.CommitAsync();
            return updateMember;
        }
    }
}
