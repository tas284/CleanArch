using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Gender).HasMaxLength(10).IsRequired();
            //builder.Property(m => m.Email).HasMaxLength(250).IsRequired();
            //builder.Property(m => m.BirthDate).IsRequired();
            //builder.Property(m => m.Active).IsRequired();

            //builder.HasData(
            //    new Member(1, "Tiago", "Saldanha", "Masculino", "tiago.avila.saldanha@gmail.com", DateTime.Now, true),
            //    new Member(2, "Júnior", "Saldanha", "Masculino", "junior.silva.saldanha@gmail.com", DateTime.Now, true)
            //    );
        }
    }
}
