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
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=League_EFCore",
        sqloptions => 
        {
            /* Make DB more resilent against miliscious entries*/
            sqloptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        })
        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        .EnableSensitiveDataLogging(); //Show the Data Logging to the DB // TEST PURPOSE ONLY!! 
    }

    /* When Building the DB */ 
    // Defining the rules MANY to MANY Relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Let the DB know that this is a VIEW TABLE
        // New Model directs to the model inside the DB mapped as this VIEW and has NO Primary Key. No Tracking
        modelBuilder.Entity<TeamCoachLeagueView>().HasNoKey().ToView("TeamCoachLeague");

        //Call the SeedConfig.cs
        modelBuilder.ApplyConfiguration(new LeagueConfig());
        modelBuilder.ApplyConfiguration(new TeamConfig());
        modelBuilder.ApplyConfiguration(new CoachConfig());

        /* Temporary Tables*/
        /* Set All FK RelationShips to Restrict*/
        var foreignKeys = modelBuilder.Model.GetEntityTypes()
            .SelectMany(select => select.GetForeignKeys())
            .Where(select => !select.IsOwnership && select.DeleteBehavior == DeleteBehavior.Cascade);

        foreach(var fk in foreignKeys)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        /* Indicate the History Table */
        modelBuilder.Entity<Team>().ToTable("Teams", build => build.IsTemporal());
    }
    
    /* Pre-Convention Model Configuration */
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<string>().HaveMaxLength(50);
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<TeamCoachLeagueView> TeamCoachLeague { get; set; }
}
