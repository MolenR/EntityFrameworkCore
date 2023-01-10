using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EntityFrameWorkCore.Data.Configurations.Entities;

public class TeamConfig : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        /* Data Validation and Constrains*/
        //builder.Property(prop => prop.Name).HasMaxLength(50);
        builder.HasIndex(index => index.Name).IsUnique();
        
        builder
            .HasMany(team => team.HomeMatches)
            .WithOne(team => team.HomeTeam)
            .HasForeignKey(team => team.HomeTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(team => team.AwayMatches)
            .WithOne(team => team.AwayTeam)
            .HasForeignKey(team => team.AwayTeamId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

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
