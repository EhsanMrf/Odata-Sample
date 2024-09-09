namespace Utility.AuditModel;

public class BaseEntity<T> : FullAudit<T> where T : struct
{
    public bool IsDeleted { get; protected set; } = false;

    protected void SetAudit(Guid createdBy)
    {
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        SetModificationProps(createdBy);
    }

    protected void SetModificationProps(Guid actorId)
    {
        ModifiedOn = DateTime.Now;
        ModifiedBy = actorId;
    }
}