using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class LeagueSeedConfig : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        /* Data Entries*/
        // Initiliaze New ModelEntity
        builder.HasData(
                new League
                {
                    Id = 4,
                    Name = "Eredivisie",
                }
            );
    }
}
