using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(int id);
    }
}
