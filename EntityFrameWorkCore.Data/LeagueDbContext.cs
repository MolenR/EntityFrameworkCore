using EntityFrameWorkCore.Data.Configurations.Entities;
using EntityFrameWorkCore.Domain;
using EntityFrameWorkCore.Domain.Common;
using EntityFrameWorkCore.Domain.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameWorkCore.Data;

public class LeagueDbContext : AuditLeagueDbContext
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

        // Let the DB know that this is a VIEW TABLE
        // New Model directs to the model inside the DB mapped as this VIEW and has NO Primary Key. No Tracking
        modelBuilder.Entity<TeamCoachLeagueView>().HasNoKey().ToView("TeamCoachLeague");

        //Call the SeedConfig.cs
        modelBuilder.ApplyConfiguration(new LeagueSeedConfig());
        modelBuilder.ApplyConfiguration(new TeamSeedConfig());
        modelBuilder.ApplyConfiguration(new CoachSeedConfig());
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<TeamCoachLeagueView> TeamCoachLeague { get; set; }
}
