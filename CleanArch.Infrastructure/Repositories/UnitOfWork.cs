using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Context;
using System.Data;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberDapperRepository _memberDapperRepository;
        private readonly IDbConnection _dbConnection;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                return _memberRepository ?? new MemberRepository(_context);
            }
        }

        public IMemberDapperRepository MemberDapperRepository
        {
            get
            {
                return _memberDapperRepository ?? new MemberDapperRepository(_dbConnection);
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
