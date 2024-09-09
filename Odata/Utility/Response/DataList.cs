namespace Utility.Response;

public class DataList<T>
{
    public T? Items { get;private set; }
    public int PageNumber { get;private set; }
    public int PageSize { get;private set; }
    public int TotalCount { get;private set; }

    private DataList()
    {
        
    }
    private DataList(T? items, int pageNumber, int pageSize, int totalCount)
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static DataList<T> DataListInstance<T>(T? items, int pageNumber, int pageSize, int totalCount)
    {
        return new DataList<T>(items, pageNumber, pageSize, totalCount);
    }

    public static DataList<T> DataListInstance()
    {
        return new DataList<T>();
    }

}

public class DataListDetail
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    private DataListDetail(int pageNumber, int pageSize, int totalCount)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static DataListDetail DataListDetailInstance(int pageNumber, int pageSize, int totalCount)
    {
        return new DataListDetail(pageNumber, pageSize, totalCount);
    }

    public (int page, int pageSize, int totalCount) GetDetails()
    {
        return (PageNumber, PageSize, TotalCount);
    }
}