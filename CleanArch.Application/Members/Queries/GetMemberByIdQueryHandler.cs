﻿using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Members.Queries
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMemberByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (member == null)
                throw new ArgumentNullException("Member not found");

            return member;
        }
    }
}
