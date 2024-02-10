namespace CleanArch.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        Task CommitAsync();
    }
}
