using Eventos.IO.Domain.Events;
using Eventos.IO.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Data.MapConfiguration;

public class AddressConfiguration : EntityTypeConfiguration<Address>
{
    public override void Map(EntityTypeBuilder<Address> builder)
    {
        builder
            .HasOne(a => a.Event)
            .WithOne(a => a.Address)
            .HasForeignKey<Address>(a => a.EventId)
            .IsRequired(false);

        builder
           .Ignore(a => a.ValidationResult);

        builder
            .Ignore(a => a.CascadeMode);

        builder
            .ToTable("Addresses");
    }
}
