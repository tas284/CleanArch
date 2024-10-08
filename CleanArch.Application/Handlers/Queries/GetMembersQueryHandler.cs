﻿using CleanArch.Application.Members.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Handlers.Queries
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMembersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _unitOfWork.MemberDapperRepository.GetMembers();
            return members;
        }
    }
}
