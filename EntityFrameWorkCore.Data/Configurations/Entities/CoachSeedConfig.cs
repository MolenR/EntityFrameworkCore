using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class CoachSeedConfig : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        /* Data Entries*/
        // Initiliaze New ModelEntity
        builder.HasData(
                new Coach
                {
                    Id = 4,
                    Name = "Jurgen Klopp",
                    TeamId = 6,
                }
            );
    }
}
