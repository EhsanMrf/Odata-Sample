namespace Utility.AuditModel;

public class EntityId<T> where T : struct
{
    public T Id { get; set; }

    public override bool Equals(object obj)
    {
        if (this.GetType() != obj.GetType()) return false;
        var otherId = obj as EntityId<T>;
        return otherId != null && otherId.Id.Equals(this.Id);
    }
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}