using EntityFrameWorkCore.Domain.Common;

namespace EntityFrameWorkCore.Domain;

public class Match : BaseDataDomain // Inheritance from the BaseDataDomain.cs
{
    public int HomeTeamId { get; set; }
    public virtual Team HomeTeam { get; set; }

    public int AwayTeamId { get; set; }
    public virtual Team AwayTeam { get;}

    public DateTime Date { get; set; }
}
