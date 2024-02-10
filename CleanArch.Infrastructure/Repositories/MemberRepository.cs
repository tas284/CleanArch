﻿using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _db;

        public MemberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Member> GetMemberById(int id)
        {
            var member = await _db.Members.FindAsync(id);

            if (member == null)
                throw new InvalidOperationException("Member not found");

            return member;
        }

        public IEnumerable<Member> GetMembers()
        {
            var members = _db.Members.ToList();
            return members ?? Enumerable.Empty<Member>();
        }

        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            _db.Members.Update(member);    
        }

        public async Task<Member> AddMember(Member member)
        {
            if(member == null)
                throw new ArgumentNullException(nameof(member));

            await _db.Members.AddAsync(member);
            return member;
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            var member = await GetMemberById(memberId);

            if (member == null)
                throw new InvalidOperationException("Member not found");

            _db.Members.Remove(member);

            return member;
        }
    }
}
