using Domain.Model;
using Microsoft.AspNetCore.OData.Query;
using Odata.Contract.Dtos;
using Utility.marker;
using Utility.Response;

namespace Odata.Contract.Interface;

public interface IAreaService: ITransientService
{
    Task<ServiceResponse<AreaDto?>> Get(short id,ODataQueryOptions<Area> dataRequest);
    Task<ServiceResponse<DataList<IEnumerable<AreaDto>>>> GetList(ODataQueryOptions<Area> dataRequest);
    Task Create(AreaSave input);
    Task Update(short id,AreaSave input);
    Task Delete(short id);
    Task Active(short id);
    Task DeActive(short id);
}