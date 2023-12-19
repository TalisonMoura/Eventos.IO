using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Organizers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eventos.IO.Data.Context;

public class EventContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region FluentApi

        #region Event

        modelBuilder.Entity<Event>()
            .Property(e => e.Name)
            .HasColumnType("varchar(150)")
            .IsRequired();

        modelBuilder.Entity<Event>()
            .Property(e => e.ShortDescription)
            .HasColumnType("varchar(150)");

        modelBuilder.Entity<Event>()
            .Property(e => e.LongDescription)
            .HasColumnType("varchar(max)");

        modelBuilder.Entity<Event>()
            .Property(e => e.CompanyName)
            .HasColumnType("varchar(150)")
            .IsRequired();

        modelBuilder.Entity<Event>()
            .Ignore(e => e.ValidationResult);

        modelBuilder.Entity<Event>()
            .Ignore(e => e.Tags);

        modelBuilder.Entity<Event>()
            .Ignore(e => e.CascadeMode);

        modelBuilder.Entity<Event>()
            .ToTable("Events");

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.OrganizerId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Category)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired(false);

        #endregion

        #region Address

        modelBuilder.Entity<Address>()
            .HasOne(a => a.Event)
            .WithOne(a => a.Address)
            .HasForeignKey<Address>(a => a.EventId)
            .IsRequired(false);

        modelBuilder.Entity<Address>()
           .Ignore(a => a.ValidationResult);

        modelBuilder.Entity<Address>()
            .Ignore(a => a.CascadeMode);

        modelBuilder.Entity<Address>()
            .ToTable("Addresses");

        #endregion

        #region Organizer

        modelBuilder.Entity<Organizer>()
           .Ignore(a => a.ValidationResult);

        modelBuilder.Entity<Organizer>()
            .Ignore(a => a.CascadeMode);

        modelBuilder.Entity<Organizer>()
            .ToTable("Organizers");

        #endregion

        #region Category

        modelBuilder.Entity<Category>()
           .Ignore(a => a.ValidationResult);

        modelBuilder.Entity<Category>()
            .Ignore(a => a.CascadeMode);

        modelBuilder.Entity<Category>()
            .ToTable("Categories");

        #endregion

        #endregion

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        base.OnConfiguring(optionsBuilder);
    }
}
