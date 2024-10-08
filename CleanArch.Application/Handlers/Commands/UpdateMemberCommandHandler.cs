﻿using CleanArch.Application.Commands;
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
            var member = await _unitOfWork.MemberDapperRepository.GetMemberById(request.Id);

            request.UpdateMember(member);

            _unitOfWork.MemberRepository.UpdateMember(member);
            await _unitOfWork.CommitAsync();
            return member;
        }
    }
}
