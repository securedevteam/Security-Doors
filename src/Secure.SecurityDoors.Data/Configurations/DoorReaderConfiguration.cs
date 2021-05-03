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
    /// EF Configuration for DoorReader entity.
    /// </summary>
    public class DoorReaderConfiguration : IEntityTypeConfiguration<DoorReader>
    {
        public void Configure(EntityTypeBuilder<DoorReader> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(DbTable.DoorReaders, DbSchema.Org)
                .HasKey(doorReader => doorReader.Id);

            builder.Property(doorReader => doorReader.SerialNumber)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.SqlMaxLengthMedium);

            builder.Property(doorReader => doorReader.Type)
                .HasConversion(new EnumToNumberConverter<DoorReaderType, int>());

            builder.Property(doorReader => doorReader.Comment)
                .HasMaxLength(SqlConfiguration.SqlMaxLengthLong);

            builder.HasOne(doorReader => doorReader.Door)
                .WithMany(door => door.DoorReaders)
                .HasForeignKey(doorReader => doorReader.DoorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
