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
    /// EF Configuration for Door entity.
    /// </summary>
    public class DoorConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(DbTable.Doors, DbSchema.Org)
                .HasKey(door => door.Id);

            builder.Property(door => door.Name)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthShort);

            builder.Property(door => door.Description)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(door => door.Status)
                .HasConversion(new EnumToNumberConverter<DoorStatusType, int>());

            builder.Property(door => door.Level)
                .HasConversion(new EnumToNumberConverter<LevelType, int>());

            builder.Property(door => door.Comment)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);
        }
    }
}
