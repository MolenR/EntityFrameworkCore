using EntityFrameWorkCore.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Data;

public abstract class AuditLeagueDbContext : DbContext
{
    //Modified the SaveChanges 
    public async Task<int> SaveChangesAsync(string username)
    {
        //Track the State of Entries 
        var entries = ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            //Casting entity for interaction
            var auditObject = (BaseDataDomain)entry.Entity;
            //Add LastModifiedDate 
            auditObject.LastModifiedDate = DateTime.UtcNow;
            auditObject.ModifiedBy = username;

            if (entry.State == EntityState.Added)
            {
                auditObject.CreatedDate = DateTime.UtcNow;
                auditObject.CreatedBy = username;
            }
        }

        return await base.SaveChangesAsync();
    }
}
