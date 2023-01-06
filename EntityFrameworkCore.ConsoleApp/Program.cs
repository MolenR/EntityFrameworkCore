using EntityFrameWorkCore.Data;
using EntityFrameWorkCore.Domain;

namespace EntityFrameworkCore.ConsoleApp;

public class Program
{
    private static readonly LeagueDbContext leagueDbContext = new();

    static async Task Main(string[] args)
    {

        await leagueDbContext.Leagues.AddAsync(new League { Name = "Premiere League"});
        
        await leagueDbContext.SaveChangesAsync();

        Console.WriteLine();
    }
}