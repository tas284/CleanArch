using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Task<Member> GetMemberById(int id);
        Task<Member> AddMember(Member member);
        void UpdateMember(Member member);
        Task DeleteMember(int memberId);
    }
}
