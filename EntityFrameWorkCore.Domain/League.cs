using EntityFrameWorkCore.Domain.Common;

namespace EntityFrameWorkCore.Domain;

public class League : BaseDataDomain // Inheritance from the BaseDataDomain.cs
{
    /* Follow Namingsconvensions EF Core will work for you*/

    // Gain access to Team.cs
    public List<Team> Teams { get; set; }
}
