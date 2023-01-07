using EntityFrameWorkCore.Domain.Common;

namespace EntityFrameWorkCore.Domain;

public class Coach : BaseDataDomain
{
    public int? TeamId { get; set; } // Nullable because ? it can be NULL
    public virtual Team Team { get; set; }
}
