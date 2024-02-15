using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> AddMember(Member member);
        void UpdateMember(Member member);
        Task DeleteMember(int memberId);
    }
}
