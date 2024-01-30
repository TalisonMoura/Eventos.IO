using Eventos.IO.Domain.Events;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infra.Data.MapConfiguration;

public class EventConfiguration : EntityTypeConfiguration<Event>
{
    public override void Map(EntityTypeBuilder<Event> builder)
    {
        builder
            .Property(e => e.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder
            .Property(e => e.ShortDescription)
            .HasColumnType("varchar(150)");

        builder
            .Property(e => e.LongDescription)
            .HasColumnType("text");

        builder
            .Property(e => e.CompanyName)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder
            .Ignore(e => e.ValidationResult);

        builder
            .Ignore(e => e.Tags);

        builder
            .Ignore(e => e.CascadeMode);

        builder
            .ToTable("Events");

        builder
            .HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId);

        builder
            .HasOne(e => e.Category)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired(false);
    }
}
