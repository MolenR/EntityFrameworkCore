using EntityFrameWorkCore.Data.Configurations.Entities;
using EntityFrameWorkCore.Domain;
using EntityFrameWorkCore.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameWorkCore.Data;

/* Reference directly configurations andotation */
//[EntityTypeConfiguration(typeof(TeamConfig))]
public class Match : BaseDataDomain // Inheritance from the BaseDataDomain.cs
{
    public int HomeTeamId { get; set; }
    public virtual Team HomeTeam { get; set; }
    public int AwayTeamId { get; set; }
    public virtual Team AwayTeam { get;}

    /* Add Using Statement */
    //[Precision(18, 2)] // andotation
    //public decimal TicketPrice { get; set; }

    public DateTime Date { get; set; }
}
