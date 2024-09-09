using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace Utility.Response;

public static class QueryExtension
{
    public static IQueryable<T> ApplyTo<T>(this IQueryable<T> queryable, ODataQueryOptions<T> dataRequest)
    {
        return (IQueryable<T>)dataRequest.ApplyTo(queryable);
    }

    public static async Task<ServiceResponse<DataList<IEnumerable<T>>>> ApplyLis<T>(this IQueryable<T>? queryable, ODataQueryOptions<T> dataRequest)
    {
        queryable = dataRequest.ApplyTo(queryable) as IQueryable<T>;
        var total = await queryable.CountAsync();
        var data = await queryable.ToListAsync();
        return await data.ReturnData(DataListDetail.DataListDetailInstance(1, 1, total));
    }

}