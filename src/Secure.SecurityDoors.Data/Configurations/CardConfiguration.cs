using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Secure.SecurityDoors.Data.Constants;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using System;

namespace Secure.SecurityDoors.Data.Configurations
{
    /// <summary>
    /// EF Configuration for Card entity.
    /// </summary>
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(DbTable.Cards, DbSchema.Org)
                .HasKey(card => card.Id);

            builder.HasAlternateKey(card => card.UniqueNumber);

            builder.Property(card => card.UniqueNumber)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(card => card.Status)
                .HasConversion(new EnumToNumberConverter<CardStatusType, int>());

            builder.Property(card => card.Level)
                .HasConversion(new EnumToNumberConverter<LevelType, int>());

            builder.Property(card => card.ExpirationTime)
                .HasColumnType(SqlConfiguration.SqlDateFormat);

            builder.Property(card => card.Comment)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);

            builder.HasOne(card => card.User)
                .WithMany(user => user.Cards)
                .HasForeignKey(card => card.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
