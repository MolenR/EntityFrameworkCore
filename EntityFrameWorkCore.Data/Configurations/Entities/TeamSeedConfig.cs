using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class TeamSeedConfig : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        /* Data Entries*/
        // Initiliaze New ModelEntity
        builder.HasData(
                new Team
                {
                    Id = 10,
                    Name = "Ajax",
                    LeagueId = 4,
                }
            );
    }
}
