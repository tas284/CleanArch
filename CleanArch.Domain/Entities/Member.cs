using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Validations;
using System.Text.Json.Serialization;

namespace CleanArch.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        //public string? Email { get; set; }
        //public DateTime? BirthDate { get; set; }
        //public bool? Active { get; set; }

        private Member() { }

        public Member(int id, string firstname, string lastname, string? gender)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
        }


        public Member(string firstname, string lastname, string? gender)
        {
            FirstName = firstname;
            LastName = lastname;
            Gender = gender;
        }

        //public Member(int id, string firstname, string lastname, string gender, string email, DateTime birthdate, bool? active)
        //{
        //    DomainValidation.When(id < 0, "Invalid Id value.");
        //    Id = id;
        //    ValidateDomain(firstname, lastname, gender, email, birthdate, active);
        //}

        //public Member(string firstname, string lastname, string gender, string email, DateTime birthdate, bool? active)
        //{
        //    ValidateDomain(firstname, lastname, gender, email, birthdate, active);
        //}

        //public void Update(string firstname, string lastname, string gender, string email, DateTime? birthdate, bool? active)
        //{
        //    ValidateDomain(firstname, lastname, gender, email, birthdate, active);
        //}

        //private void ValidateDomain(string firstname, string lastname, string gender, string email, DateTime? birthdate, bool? active)
        //{
        //    DomainValidation.When(string.IsNullOrEmpty(firstname),
        //        "Invalid name, FirsName is required.");

        //    DomainValidation.When(firstname.Length < 3,
        //        "Invalid name, too short, minimum 3 characters.");

        //    DomainValidation.When(string.IsNullOrEmpty(lastname),
        //        "Invalid lastname, LastName is required.");

        //    DomainValidation.When(lastname.Length < 3,
        //        "Invalid lastname, too short, minimum 3 characters.");

        //    DomainValidation.When(email.Length < 6,
        //        "Invalid email, too short, minimum 6 characters.");

        //    DomainValidation.When(email.Length > 250,
        //        "Invalid email, too long, maximun 250 characters.");

        //    DomainValidation.When(string.IsNullOrEmpty(gender),
        //        "Invalid gender, Gender is required.");

        //    DomainValidation.When(!active.HasValue,
        //        "Must define activity.");

        //    DomainValidation.When(!birthdate.HasValue,
        //        "Must define birthdate.");

        //    FirstName = firstname;
        //    LastName = lastname;
        //    Gender = gender;
        //    Email = email;
        //    BirthDate = birthdate;
        //    Active = active;
        //}
    }
}
