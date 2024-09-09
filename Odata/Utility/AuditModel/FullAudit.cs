namespace Utility.AuditModel;

public class FullAudit<T> : EntityId<T> where T : struct
{
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; } = DateTime.Now;
    public Guid ModifiedBy { get; set; }

}