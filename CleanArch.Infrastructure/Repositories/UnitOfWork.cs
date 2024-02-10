﻿using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IMemberRepository _memberRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                return _memberRepository ?? new MemberRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
