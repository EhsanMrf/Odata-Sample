using Domain.Model;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Utility.Response;

namespace Persistence.EF.Repository;

public class AreaRepository : IAreaRepository
{
    private readonly OdataDbContext _db;

    public AreaRepository(OdataDbContext db)
    {
        _db = db;
    }

    public async Task<ServiceResponse<Area?>> Get(short id, ODataQueryOptions<Area> request)
    {
        var area= await _db.Areas.Where(x => x.Id == id).AsNoTracking().ApplyTo(request).FirstOrDefaultAsync();
        return area.ReturnData();
    }

    public async Task<Area?> Load(short id)
    {
        return await _db.Areas.Where(x => x.Id == id).AsTracking().FirstOrDefaultAsync();
    }

    public async Task<ServiceResponse<DataList<IEnumerable<Area>>>> GetList(ODataQueryOptions<Area> request)
    {
        return await _db.Areas.ApplyLis(request);
    }

    public async Task Create(Area model)
    {
        _db.Areas.Add(model);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Area model)
    {
        _db.Areas.Update(model);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> IsExists(Area area)
    {
        return await _db.Areas.AnyAsync(x => x.Id != area.Id && (x.Title.Equals(area.Title) || x.Code==area.Code));
    }
}