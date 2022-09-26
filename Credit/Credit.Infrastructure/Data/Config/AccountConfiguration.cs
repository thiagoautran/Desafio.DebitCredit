using Credit.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Credit.Infrastructure.Data.Config
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Agency)
                .HasColumnName("Agency")
                .IsRequired();

            builder.Property(x => x.AccountNumber)
                .HasColumnName("AccountNumber")
                .IsRequired();

            builder.Property(x => x.CurrentAccountDigit)
                .HasColumnName("CurrentAccountDigit")
                .IsRequired();

            builder.Property(x => x.Balance)
                .HasColumnName("Balance")
                .IsRequired();

            builder.Property(x => x.PersonId)
                .HasColumnName("PersonId")
                .IsRequired();
        }
    }
}