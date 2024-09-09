using Domain.Model;
using Odata.Contract.Dtos;
using Utility.Response;

namespace Odata.Contract.Mapper;

public static class AreaMapper
{
    public static AreaDto ToDto(this Area model)
    {
        return new AreaDto(model.Id,model.Title, model.IsActive, model.Code);
    }

    public static Area ToDto(this AreaSave input)
    {
        return new Area(input.Title, input.Code, input.IsActive, Guid.Empty, Guid.Empty);
    }

    public static IEnumerable<AreaDto> ToDto(this IEnumerable<Area>? models)
    {
        return models!.Select(x => new AreaDto(x.Id, x.Title, x.IsActive, x.Code));
    }
}