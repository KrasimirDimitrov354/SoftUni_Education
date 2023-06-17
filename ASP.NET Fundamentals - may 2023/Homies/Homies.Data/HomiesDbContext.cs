namespace Homies.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Homies.Data.Models;
using Homies.Data.Configuration;

public class HomiesDbContext : IdentityDbContext
{
    public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
        : base(options)
    {

    }

    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Type> Types { get; set; } = null!;
    public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TypeEntityConfiguration());

        modelBuilder.Entity<EventParticipant>()
            .HasKey(pk => new { pk.HelperId, pk.EventId });

        modelBuilder.Entity<EventParticipant>()
            .HasOne(e => e.Event)
            .WithMany()
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EventParticipant>()
            .HasOne(e => e.Helper)
            .WithMany()
            .HasForeignKey(e => e.HelperId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}