using EntityFrameWorkCore.Data;
using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityFrameworkCore.ConsoleApp;

public class Program
{
    private static readonly LeagueDbContext context = new();

    static async Task Main(string[] args)
    {
        /////* Call Method */////

        //await AddTeam();
        //await DeleteTeam();
        //await SelectQuery();
        //await QueryFilters();
        await TeamQuery();
        await TemporaryTeamQuery();

        //////////////////////////////
        Console.WriteLine("Press Key");
        Console.ReadKey();
    }

    /* Create Read Update Delete -- CRUD Operations */
    /* Language Integrated Querry -- LINQ */

    /* Insert Operation Methods*/

    private static async Task TeamQuery()
    {
        var teams = await context.Teams.ToListAsync();

        foreach(var team in teams) 
        {
            Console.WriteLine($"Team: {team.Id} - {team.Name}");
        }
    }
    private static async Task TemporaryTeamQuery()
    {
        var teamsHistory = await context.Teams.TemporalAll().ToListAsync();

        foreach (var team in teamsHistory)
        {
            Console.WriteLine($"Team: {team.Id} - {team.Name}");
        }
    }

    
    /* Add single object to the DB */
    private static async Task AddTeam()
    {
        var transaction = context.Database.BeginTransaction();

        await transaction.CreateSavepointAsync("Add Team");
        try
        {
            var team = new Team
            {
                Name = "Chelsea",
                LeagueId = 2,   
            };

            context.Teams.Update(team);
            await context.SaveChangesAsync("Test Save Changes User");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync("Add Team");
            Console.WriteLine($"Commit Failed: {ex}");
        }
    }
    //private static async Task DeleteTeam()
    //{
    //    var team = await context.Teams.FindAsync(12);
    //    context.Teams.Remove(team);
    //    await context.SaveChangesAsync();
    //}
    //private static async Task SelectOneProperty()
    //{
    //    var teams = await context.Teams.Select(team => team.Name).ToListAsync();
    //}
    ///* Adding 1 - N Related Records */
    //private static async Task AddNewLeague()
    //{
    //    var teams = new List<Team>
    //    {
    //        new Team
    //        {
    //            Id = 11,
    //            Name = "Bayern Munchen",
    //            LeagueId = 5,
    //        }
    //    };
    //    var league = new League { Name = "BundisLiga", Teams = teams };
    //    await context.AddAsync(league);
    //    await context.SaveChangesAsync("Test Save Changes User");
    //}
    ///* Filter Based Related Data*/
    //private static async Task FilterRelatedData()
    //{
    //    var leagues = await context.Leagues
    //        .Where(league => league.Teams
    //        .Any(l => l.Name.Contains("")))
    //        .ToListAsync();
    //}
    ///* Projections Other Data Types or Anonymous Types*/
    //private static async Task AnonymousProjection()
    //{
    //    var teams = await context.Teams
    //        .Include(team => team.Name)
    //        .Select(team => new // Custom Object 
    //        { 
    //            TeamName = team.Name
    //        })
    //        .ToListAsync();
    //}
    //private static async Task TypedProjections()
    //{
    //    var teams = await context.Teams
    //        .Include(team => team.Name)
    //        .Select(team => new //TeamDetails // Add Class // Custom Object // Custom made data class 
    //        {
    //            TeamName = team.Name
    //        })
    //        .ToListAsync();
    //}
    ///* Including Related Data - Eager Loading*/
    //private static async Task QueryRelatedRecords()
    //{
    //    // Get Many Related Records - Leagues -> Teams
    //    var leagues = await context.Leagues
    //        .Include(league => league.Teams)
    //        .ToListAsync(); 
    //    //SELECT    [l].[Id], [l].[Name], [t].[Id], [t].[LeagueId], [t].[Name]
    //    //FROM      [Leagues] AS[l]
    //    //LEFT JOIN [Teams] AS[t] ON[l].[Id] = [t].[LeagueId]
    //    //ORDER BY  [l].[Id]

    //    // Get One Related Record - Team -> Coach

    //    /*NO WORKING COACH TABLE*/
    //    var team = await context.Teams
    //        .Include(team => team.Coach)
    //        .FirstOrDefaultAsync(team => team.Id == 1);

    //    // Get 'Childeren' Related Records - Team -> Matches Home/Away Team

    //    /* NO WORKING MATCHES TABLE */
    //    var teamsWithMatch = await context.Teams
    //        // Includes
    //        .Include(team => team.AwayMatches)
    //            .ThenInclude(team => team.HomeTeam)
    //            .ThenInclude(team => team.Coach)
    //        .Include(team => team.HomeMatches)
    //            .ThenInclude(team => team.AwayTeam)
    //            .ThenInclude(team => team.Coach)
    //        // Executes
    //        .FirstOrDefaultAsync(team => team.Id == 1);
    //}
    ///* Adding N - M Related Records */
    ////private static async Task AddNewMatch()
    ////{
    ////    var matches = new List<Match>
    ////    {
    ////        new Match
    ////        {
    ////            AwayTeamId = 5, HomeTeamId = 6, Date = new DateTime()
    ////        }
    ////    };
    ////    await context.AddRangeAsync(matches);
    ////    await context.SaveChangesAsync();
    ////}
    ///* Tracking vs No-Tracking*/
    //private static async Task Tracking()
    //{
    //    var withTracking = await context.Teams.FirstOrDefaultAsync(team => team.Id == 5);

    //    // Without Tracking the DB Query 
    //    var withoutTracking = await context.Teams.AsNoTracking().FirstOrDefaultAsync(team => team.Id == 4);

    //    withTracking.Name = "Arsenal";
    //    withoutTracking.Name = "Foo";

    //    var beforeSave = context.ChangeTracker.Entries();
    //    await context.SaveChangesAsync();

    //    var afterSave = context.ChangeTracker.Entries();
    //}
    ///*Perform Delete*/
    //private static async Task DeleteLeague()
    //{
    //    var league = await context.Leagues.FindAsync(3);
    //    context.Leagues.Remove(league);
    //    await context.SaveChangesAsync();
    //}
    //private static async Task DeleteRelationship()
    //{
    //    var league = await context.Leagues.FindAsync(4);
    //    context.Leagues.Remove(league);
    //    await context.SaveChangesAsync();
    //}
    ///* Working w/ Records */
    //private static async Task UpdateTeam()
    //{
    //    /* Update Data to the DB*/
    //    var coach = new Coach
    //    {
    //        Name = "Louis van Gaal",
    //    };
    //    context.Coaches.Update(coach);
    //    await context.SaveChangesAsync();
    //}
    //private static async Task UpdateLeague()
    //{
    //    /* Retrieve Record */
    //    var league = await context.Leagues.FindAsync(2);

    //    /* Make Record Changes */
    //    league.Name = "EreDivisie";

    //    /* Save Changes */
    //    context.SaveChanges();

    //    /* Retrieve Updated Records */
    //    await GetRecord();
    //}
    //private static async Task GetRecord()
    //{
    //    var league = await context.Leagues.FindAsync(2);
    //    Console.WriteLine($"{league.Id} - {league.Name}");
    //}    
    ///* LINQ without Lambda Expression*/
    //private static async Task AlterLinqSyntax()
    //{
    //    Console.Write($"Enter Team: ");
    //    var teamName = Console.ReadLine;
    //    var teams = await (from t 
    //                       in context.Teams
    //                       where EF.Functions.Like(t.Name, $"{teamName}")
    //                       select t).ToListAsync(); //SELECT [t].[Id], [t].[LeagueId], [t].[Name] FROM[Teams] AS[t]
    //    foreach (var team in teams)
    //    {
    //        Console.WriteLine($"{team.Id} - {team.Name}");
    //    }
    //}
    ///* Aggregate Functions */
    //private static async Task AdditionalExecuteMethods()
    //{
    //    //var executionMethod = context.Leagues.FirstOrDefaultAsync(league => league.Name.Contains('E'));

    //    var executionMethod = context.Leagues;

    //    var list = await executionMethod.ToListAsync();

    //    // DbSet Method that will Execute
    //    var league = await executionMethod.FindAsync(1);
    //}
    ///* Queries w/ Filters */
    //private static async Task QueryFilters()
    //{
    //    Console.Write("Enter League: ");
    //    var leagueName = Console.ReadLine();

    //    var exactName = await context.Leagues.Where(league => league.Name.Equals(leagueName)).ToListAsync();

    //    foreach (League league in exactName)
    //    {
    //        Console.WriteLine($"{league.Id} - {league.Name}");
    //    }

    //    //var partialName = await context.Leagues.Where(league => league.Name.Contains(newLeagueName)).ToListAsync();

    //    var partialName = await context.Leagues.Where(league => EF.Functions.Like(league.Name, $"{leagueName}")).ToListAsync();

    //    foreach (League league in partialName)
    //    {
    //        Console.WriteLine($"{league.Id} - {league.Name}");
    //    }
    //}
    ///* Select Queries */
    //private static async Task SelectQuery()
    //{
    //    /* SELECT * FROM LEAGUES */
    //    var leagues = await context.Leagues.ToListAsync();

    //    foreach (League league in leagues)
    //    {
    //        Console.WriteLine($"{league.Id} - {league.Name}");
    //    }
    //}
    //private static async Task AddTeamsWithLeague(League league)
    //{
    //    var teams = new List<Team>
    //    {
    //        new Team
    //        {
    //            Name = "Manchester United",
    //            LeagueId = league.Id
    //        },
    
    //        new Team
    //        {
    //            Name = "Arsenal",
    //            LeagueId = league.Id
    //        },
    
    //        new Team
    //        {
    //            Name = "Liverpool",
    //            League = league
    //        }
    //    };
        
    //    // Add multiple objects tot the DB
    //    await context.AddRangeAsync(teams);
    //}
    
    //#region RAW SQL
    ///* Non-Query Commands*/
    //private static async Task ExecuteCommand()
    //{
    //    // CAUTION USING THIS METHOD!! DANGER OF SQL INJECTION!!!
    //    var teamId = 4;
    //    var effect = await context.Database.ExecuteSqlRawAsync("EXEC dpo.sp_GetCoachName {0}", teamId);

    //    // IF RawSQL is needed use the INTERPOLATED METHOD !!
    //    var teamId1 = 9;
    //    var result = await context.Database.ExecuteSqlInterpolatedAsync($"exec dpo.sp_DeleteTeamById {teamId1}");
    //}
    ///* Query Stored Procedures*/
    //private static async Task StoredProcedure()
    //{
    //    var teamId = 4;
    //    var effect = await context.Coaches.FromSqlRaw("EXEC dpo.sp_GetCoachName {0}", teamId).ToListAsync();

    //    var teamId1 = 9;
    //    var result = await context.Coaches.FromSql($"exec dpo.sp_DeleteTeamById {teamId1}").ToListAsync();
    //}
    ///* Query w/ Raw SQL*/
    //private static async Task RawSQLQuery()
    //{
    //    string name = "test";
    //    // CAUTION USING THIS METHOD!! DANGER OF SQL INJECTION!!!
    //    //var team1 = await context.Teams.FromSqlRaw("Select * from Teams").ToListAsync(); // DO NOT USE UNLESS EXEPTION!!! 
        
    //    // IF RawSQL is needed use the INTERPOLATED METHOD !!
    //    var team2 = await context.Teams.FromSqlInterpolated($"Select * from Teams where name = {name}").ToListAsync();
    //}
    ///* Query Views*/
    //private static async Task QueryViews()
    //{
    //    var details = await context.TeamCoachLeague.ToListAsync();
    //}
    //#endregion
}