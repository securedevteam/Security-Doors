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
    /// EF Configuration for DoorAction entity.
    /// </summary>
    public class DoorActionConfiguration : IEntityTypeConfiguration<DoorAction>
    {
        public void Configure(EntityTypeBuilder<DoorAction> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(DbTable.DoorActions, DbSchema.Org)
                .HasKey(doorAction => doorAction.Id);

            builder.Property(doorAction => doorAction.Status)
                .HasConversion(new EnumToNumberConverter<DoorActionStatusType, int>());

            builder.HasOne(doorAction => doorAction.AccessController)
                .WithMany(doorReader => doorReader.DoorActions)
                .HasForeignKey(doorAction => doorAction.AccessControllerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(doorAction => doorAction.Card)
                .WithMany(card => card.DoorActions)
                .HasForeignKey(doorAction => doorAction.CardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
