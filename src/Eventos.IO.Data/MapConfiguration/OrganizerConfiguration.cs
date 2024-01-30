﻿using Eventos.IO.Infra.Data.Extensions;
using Eventos.IO.Domain.Organizers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infra.Data.MapConfiguration;

public class OrganizerConfiguration : EntityTypeConfiguration<Organizer>
{
    public override void Map(EntityTypeBuilder<Organizer> builder)
    {
        builder
            .Ignore(a => a.ValidationResult);

        builder
            .Ignore(a => a.CascadeMode);

        builder
            .ToTable("Organizers");
    }
}
