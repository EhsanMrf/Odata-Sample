namespace Utility.Exception;

public class BaseException : System.Exception
{
    public string Code { get; protected set; }
    public object Value { get; set; }

    public BaseException(string code, string message = "") : base(message)
    {
        this.Code = code;
    }

    public BaseException(object value, string code, string message = "") : base(message)
    {
        this.Code = code;
        this.Value = value;
    }
}