using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace EntityFrameWorkCore.Data;

internal class AuditEntry
{
    /* Use constructor to initialize new property for Entry Point*/
    public AuditEntry(EntityEntry entityEntry)
    {
        EntityEntry = entityEntry;
    }

    public EntityEntry EntityEntry { get; }

    public string TableName { get; set; }
    public string Action { get; set; }
    // Get The Values and initialize the Dictionary
    public Dictionary<string, object> KeyValues { get; set; } = new Dictionary<string, object>();
    public Dictionary<string, object> OldValues { get; set; } = new Dictionary<string, object>();
    public Dictionary<string, object> NewValues { get; set; } = new Dictionary<string, object>();
    public List<PropertyEntry> TempProperties { get; } = new List<PropertyEntry>();

    public bool HasTempProperties => TempProperties.Any();

    /* Building the Audit */
    public Audit ToAudit()
    {
        var audit = new Audit
        {
            DateTime = DateTime.Now,
            TableName = TableName,
            KeyValues = JsonConvert.SerializeObject(KeyValues),
            OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
            NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
            Action = Action
        };
        return audit;
    }
}