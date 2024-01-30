using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Organizers;
using Microsoft.EntityFrameworkCore;
using Eventos.IO.Infra.Data.MapConfiguration;
using Microsoft.Extensions.Configuration;
using Eventos.IO.Infra.Data.Extensions;

namespace Eventos.IO.Infra.Data.Context;

public class EventContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddConfiguration(new EventConfiguration());
        modelBuilder.AddConfiguration(new AddressConfiguration());
        modelBuilder.AddConfiguration(new CategoryConfiguration());
        modelBuilder.AddConfiguration(new OrganizerConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
    }
}