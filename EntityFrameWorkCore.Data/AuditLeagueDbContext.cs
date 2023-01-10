using EntityFrameWorkCore.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkCore.Domain;

namespace EntityFrameWorkCore.Data;

public abstract class AuditLeagueDbContext : DbContext
{
    // DBSET Audit
    public DbSet<Audit> Audits { get; set; }
    
    //Modified the SaveChanges 
    public async Task<int> SaveChangesAsync(string username)
    {
        /* Saving values before*/
        var auditEntries = OnBeforeSaveChanges(username);
        var saveResult =  await base.SaveChangesAsync();
        
        if(auditEntries != null || auditEntries.Count > 0)
        {
            await AfterSaveChanges(auditEntries);
        }

        return saveResult;
    }

    private Task AfterSaveChanges(List<AuditEntry> auditEntries)
    {
        foreach (var auditEntry in auditEntries)
        {
            foreach (var prop in auditEntry.TempProperties)
            {
                if (prop.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                }
                else
                {
                    auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                }
            }
            Audits.Add(auditEntry.ToAudit());
        }
        return SaveChangesAsync();
    }

    private List<AuditEntry> OnBeforeSaveChanges(string username)
    {
        //Track the State of Entries 
        var entries = ChangeTracker
            .Entries()
            .Where(entry => entry.State == EntityState.Added || 
                            entry.State == EntityState.Modified || 
                            entry.State == EntityState.Deleted);
        
        /* Can Cause problems by Tracking auditRecord even if NULL*/
        //var entries = ChangeTracker
        //    .Entries()
        //    .Where(entry => entry.State != EntityState.Detached || 
        //                    entry.State != EntityState.Modified); 

        var auditEntries = new List<AuditEntry>();

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

            var auditEntry = new AuditEntry(entry)
            {
                TableName = entry.Metadata.GetTableName(),
                Action = entry.State.ToString()
            };
            auditEntries.Add(auditEntry);

            /* Copy Key*/
            foreach(var property in entry.Properties)
            {
                /* Check for PlaceHolder in the Property if this is Temporary */
                if(property.IsTemporary)
                {
                    /* Is This Edit or Not*/
                    auditEntry.TempProperties.Add(property);
                    continue;
                }
                /* If Not get the Metadata if this is PrimaryKey*/
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    /* Store the Value */
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.OldValues[propertyName] = property.OriginalValue; 
                        break;
                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        }
                        break;
                }
            }

        }
        /* After Compiling withKeyValues convert to Audit Record and add it to DBSET */
        foreach(var pendingAuditEntry in auditEntries.Where(q => q.HasTempProperties == false))
        {
            Audits.Add(pendingAuditEntry.ToAudit());
        }

        return auditEntries.Where(q => q.HasTempProperties).ToList();
    }
}
