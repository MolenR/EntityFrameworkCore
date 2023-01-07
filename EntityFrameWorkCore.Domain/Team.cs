using EntityFrameWorkCore.Domain.Common;

namespace EntityFrameWorkCore.Domain;

public class Team : BaseDataDomain // Inheritance from the BaseDataDomain.cs
{
    /* Foreign Key related to Leaugue */
    public int LeagueId { get; set; }
    public virtual League League { get; set; }
    public virtual Coach Coach { get; set; }

    /* Navigation Properties */
    public virtual List<Match> HomeMatches { get; set; }
    public virtual List<Match> AwayMatches { get; set; }
}
