namespace CleanArch.Infrastructure.Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException() { }
        public MemberNotFoundException(string message) : base(message) { }
    }
}
