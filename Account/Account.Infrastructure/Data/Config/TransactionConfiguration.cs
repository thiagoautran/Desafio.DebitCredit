using Account.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Data.Config
{
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Value)
                .HasColumnName("Value")
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("Date")
                .IsRequired();

            builder.Property(x => x.AccountId)
                .HasColumnName("AccountId")
                .IsRequired();

            builder.Property(x => x.OperationId)
                .HasColumnName("OperationId")
                .IsRequired();
        }
    }
}