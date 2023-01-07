using EntityFrameWorkCore.Data;
using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.ConsoleApp;

public class Program
{
    private static readonly LeagueDbContext context = new();

    static async Task Main(string[] args)
    {
        /* Create Read Update Delete -- CRUD Operations */

        /* Language Integrated Querry -- LINQ */

        /* Insert Operation Methods*/
        //var league = new League { Name = "Premiere League" };
        //await leagueDbContext.Leagues.AddAsync(league);
        //await leagueDbContext.SaveChangesAsync();
        //await AddTeamsWithLeague(league);

        /* Add single object to the DB */
        //await leagueDbContext.SaveChangesAsync();

        /* Select Queries */
        //SelectQuery();

        /* Queries w/ Filters */
        //await QueryFilters();

        /* Aggregate Functions */
        //await AdditionalExecuteMethods();

        /* LINQ without Lambda Expression*/
        //await AlterLinqSyntax();

        /* Working w/ Records */
        //await UpdateLeague();
        //await UpdateTeam();

        /*Perform Delete*/
        //await DeleteLeague();
        //await DeleteRelationship();

        /* Tracking vs No-Tracking*/
        await Tracking();

        Console.WriteLine($"Press Key");
        Console.ReadKey();
    }

    private static async Task Tracking()
    {
        var withTracking = await context.Teams.FirstOrDefaultAsync(team => team.Id == 5);
        
        // Without Tracking the DB Query 
        var withoutTracking = await context.Teams.AsNoTracking().FirstOrDefaultAsync(team => team.Id == 4);

        withTracking.Name = "Arsenal";
        withoutTracking.Name = "Foo";

        var beforeSave = context.ChangeTracker.Entries();
        await context.SaveChangesAsync();

        var afterSave = context.ChangeTracker.Entries();
    }

    private static async Task DeleteLeague()
    {
        var league = await context.Leagues.FindAsync(3);
        context.Leagues.Remove(league);
        await context.SaveChangesAsync();
    }
    private static async Task DeleteRelationship()
    {
        var league = await context.Leagues.FindAsync(4);
        context.Leagues.Remove(league);
        await context.SaveChangesAsync();
    }
    private static async Task UpdateTeam()
    {
        /* Update Data to the DB*/
        var team = new Team
        {
            Id = 4,
            Name = "Foo",
            LeagueId = 2
        };
        context.Teams.Update(team);
        await context.SaveChangesAsync();
    }
    private static async Task UpdateLeague()
    {
        /* Retrieve Record */
        var league = await context.Leagues.FindAsync(2);

        /* Make Record Changes */
        league.Name = "EreDivisie";

        /* Save Changes */
        context.SaveChanges();

        /* Retrieve Updated Records */
        await GetRecord();
    }
    private static async Task GetRecord()
    {
        var league = await context.Leagues.FindAsync(2);
        Console.WriteLine($"{league.Id} - {league.Name}");
    }
    private static async Task AlterLinqSyntax()
    {
        Console.Write($"Enter Team: ");
        var teamName = Console.ReadLine;
        var teams = await (from t 
                           in context.Teams
                           where EF.Functions.Like(t.Name, $"{teamName}")
                           select t).ToListAsync(); //SELECT [t].[Id], [t].[LeagueId], [t].[Name] FROM[Teams] AS[t]
        foreach (var team in teams)
        {
            Console.WriteLine($"{team.Id} - {team.Name}");
        }
    }
    private static async Task AdditionalExecuteMethods()
    {
        //var executionMethod = context.Leagues.FirstOrDefaultAsync(league => league.Name.Contains('E'));
        
        var executionMethod = context.Leagues;
        
        var list = await executionMethod.ToListAsync();

        // DbSet Method that will Execute
        var league = await executionMethod.FindAsync(1);
    }
    private static async Task QueryFilters()
    {
        Console.Write("Enter League: ");
        var leagueName = Console.ReadLine();

        var exactName = await context.Leagues.Where(league => league.Name.Equals(leagueName)).ToListAsync();

        foreach (League league in exactName)
        {
            Console.WriteLine($"{league.Id} - {league.Name}");
        }
        
        //var partialName = await context.Leagues.Where(league => league.Name.Contains(newLeagueName)).ToListAsync();

        var partialName = await context.Leagues.Where(league => EF.Functions.Like(league.Name, $"{leagueName}")).ToListAsync();

        foreach (League league in partialName)
        {
            Console.WriteLine($"{league.Id} - {league.Name}");
        }
    }
    private static async Task SelectQuery()
    {
        /* SELECT * FROM LEAGUES */
        var leagues = await context.Leagues.ToListAsync();

        foreach (League league in leagues)
        {
            Console.WriteLine($"{league.Id} - {league.Name}");
        }
    }

    private static async Task AddTeamsWithLeague(League league)
    {
        var teams = new List<Team>
        {
            new Team
            {
                Name = "Manchester United",
                LeagueId = league.Id
            },

            new Team
            {
                Name = "Arsenal",
                LeagueId = league.Id
            },

            new Team
            {
                Name = "Liverpool",
                League = league
            }
        };
        
        // Add multiple objects tot the DB
        await context.AddRangeAsync(teams);
    }
}