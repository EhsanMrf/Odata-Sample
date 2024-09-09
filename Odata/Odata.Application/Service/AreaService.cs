using Domain.Model;
using Microsoft.AspNetCore.OData.Query;
using Odata.Contract.Dtos;
using Odata.Contract.Interface;
using Odata.Contract.Mapper;
using Utility.Exception;
using Utility.Response;

namespace Odata.Application.Service;

public class AreaService : IAreaService
{
    private readonly IAreaRepository _repository;

    public AreaService(IAreaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResponse<AreaDto?>> Get(short id, ODataQueryOptions<Area> dataRequest)
    {
        return await _repository.Get(id, dataRequest)!.ReturnData(x=>x.Data?.ToDto());
    }

    public async Task<ServiceResponse<DataList<IEnumerable<AreaDto>>>> GetList(ODataQueryOptions<Area> dataRequest)
    {
        return await _repository.GetList(dataRequest).ReturnData(x=>x.ToDto());
    }

    public async Task Create(AreaSave input)
    {
        await _repository.Create(input.ToDto());
    }

    public async Task Update(short id, AreaSave input)
    {
        var area = await _repository.Load(id);
        area!.Update(input.Title,input.Code,Guid.Empty, input.IsActive);
        await _repository.Update(area);
    }

    public async Task Delete(short id)
    {
        var area = await _repository.Load(id);
        if (area==null)
        {
            throw new BaseException("InValid Data");
        }
        area!.Delete();
        await _repository.Update(area);
    }

    public Task Active(short id)
    {
        throw new NotImplementedException();
    }

    public Task DeActive(short id)
    {
        throw new NotImplementedException();
    }
}