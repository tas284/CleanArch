namespace CleanArch.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        IMemberDapperRepository MemberDapperRepository { get; }
        Task CommitAsync();
    }
}
