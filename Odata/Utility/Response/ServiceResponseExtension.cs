namespace Utility.Response;

public static class ServiceResponseExtension
{
    public static ServiceResponse<T?> ReturnData<T>(this T? data)=> new(data);

    public static Task<ServiceResponse<DataList<IEnumerable<T>>>> ReturnData<T>(this IEnumerable<T> data, DataListDetail dataListDetails)
    {
        var detail= dataListDetails.GetDetails();
        var dataListInstance = DataList<List<T>>.DataListInstance(data, detail.pageSize, detail.pageSize, detail.totalCount);
        return Task.FromResult(new ServiceResponse<DataList<IEnumerable<T>>>(dataListInstance));
    }


    public static async Task<ServiceResponse<TN?>> ReturnData<T, TN>(this Task<T?> taskData, Func<T, TN> mapFunc)
    {
        var data = await taskData;

        if (data == null) 
            return new ServiceResponse<TN?>(default);

        var mappedData = mapFunc(data);
        return new ServiceResponse<TN?>(mappedData!);
    }
    public static async Task<ServiceResponse<DataList<IEnumerable<TN>>>> ReturnData<T, TN>(this Task<ServiceResponse<DataList<T>>> taskData, Func<T?, IEnumerable<TN>> mapFunc)
    {
        var serviceResponse = await taskData;

        if (serviceResponse.Data != null)
        {
            var mappedItems = mapFunc(serviceResponse.Data.Items);

            var dataList = DataList<TN>.DataListInstance(mappedItems, serviceResponse.Data.PageNumber, serviceResponse.Data.PageSize, serviceResponse.Data.TotalCount);

            return new ServiceResponse<DataList<IEnumerable<TN>>>(dataList);
        }

        return new ServiceResponse<DataList<IEnumerable<TN>>>(null);
    }
}