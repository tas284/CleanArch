namespace CleanArch.API.Models
{
    public class MemberInputModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
