
using Utility.AuditModel;
using Utility.Validator;
using static Domain.Model.AreaException;

namespace Domain.Model;

public class Area : BaseEntity<short>
{
    public string Title { get; private set; }
    public bool IsActive { get; private set; }
    public int Code { get; private set; }
    public Guid OrganizationId { get; set; }


    private Area()
    {
        
    }
    public Area(string title, int code, bool isActive, Guid actorId, Guid organizationId)
    {
        FillModel(title, code);
        IsActive = isActive;
        OrganizationId = organizationId;
        SetAudit(actorId);
    }

    public void Update(string title, int code, Guid actorId, bool isActive)
    {
        FillModel(title, code);
        IsActive = isActive;
        SetModificationProps(actorId);

    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Active()
    {
        this.IsActive = true;
    }

    public void Deactivate()
    {
        this.IsActive = false;
    }

    void FillModel(string title, int code)
    {
        ObjectValidator.Instance
            .RuleFor(title).NotNullOrEmpty(new AreaTitleInvalid())
            .RuleFor(code).NotNullOrEmpty(new AreaCodeInvalid());

        Title = title;
        Code = code;
    }
}