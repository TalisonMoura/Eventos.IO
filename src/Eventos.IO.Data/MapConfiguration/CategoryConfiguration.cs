using Eventos.IO.Domain.Events;
using Eventos.IO.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Data.MapConfiguration;

public class CategoryConfiguration : EntityTypeConfiguration<Category>
{
    public override void Map(EntityTypeBuilder<Category> builder)
    {
        builder
            .Ignore(a => a.ValidationResult);

        builder
            .Ignore(a => a.CascadeMode);

        builder
            .ToTable("Categories");
    }
}
