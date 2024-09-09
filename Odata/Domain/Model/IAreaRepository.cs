using Microsoft.AspNetCore.OData.Query;
using Utility.marker;
using Utility.Response;

namespace Domain.Model;

public interface IAreaRepository : ITransientService
{

    Task<ServiceResponse<Area?>> Get(short id, ODataQueryOptions<Area> request);
    Task<Area?> Load(short id);
    Task<ServiceResponse<DataList<IEnumerable<Area>>>> GetList(ODataQueryOptions<Area> request);

    Task Create(Area model);
    Task Update(Area model);
    Task<bool> IsExists(Area area);
}