using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameWorkCore.Data;

public class LeagueDbContext : DbContext
{
    // String builder to locate the SQLDB
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=League_EFCore")
                      .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                      .EnableSensitiveDataLogging(); //Show the Data Logging to the DB // TEST PURPOSE ONLY!! 
    }

    /* When Building the DB */ 

    // Defining the rules MANY to MANY Relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>()
            .HasMany(team => team.HomeMatches)
            .WithOne(team => team.HomeTeam)
            .HasForeignKey(team => team.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Team>()
            .HasMany(team => team.AwayMatches)
            .WithOne(team => team.AwayTeam)
            .HasForeignKey(team => team.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Coach> Coaches { get; set; }
}
