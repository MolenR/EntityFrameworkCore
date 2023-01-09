namespace EntityFrameWorkCore.Domain.Common;

public abstract class BaseDataDomain
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
}
