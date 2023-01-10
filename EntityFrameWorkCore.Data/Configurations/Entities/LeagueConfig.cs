using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class LeagueConfig : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        //builder.Property(prop => prop.Name).HasMaxLength(50);
        builder.HasIndex(index => index.Name);

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
