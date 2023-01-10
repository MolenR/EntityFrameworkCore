using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class CoachConfig : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        //builder.Property(prop => prop.Name).HasMaxLength(50);
        
        builder.HasIndex(index => new { index.Name });

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
