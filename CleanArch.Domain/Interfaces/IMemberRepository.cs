using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetMemberById(int id);
        Task<Member> AddMember(Member member);
        Task<Member> UpdateMember(Member member);
        Task DeleteMember(int memberId);
    }
}
