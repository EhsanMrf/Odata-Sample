namespace Utility.Response;

public class ServiceResponse<T>
{
    public T? Data { get; set; }

    protected ServiceResponse() { }
    public ServiceResponse(T? data)
    {
        if (data==null) 
            Data = default;
        
        Data = data;
    }
}