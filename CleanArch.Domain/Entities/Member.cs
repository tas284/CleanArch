using CleanArch.Domain.Abstractions;

namespace CleanArch.Domain.Entities
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
