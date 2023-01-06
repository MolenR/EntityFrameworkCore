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

    public DbSet<Team> Teams { get; set; }
    public DbSet<League> Leagues { get; set; }
}
