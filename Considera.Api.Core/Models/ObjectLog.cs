namespace Considera.Api.Core.Models;

public class ObjectLog<T>
{
    public T? Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    
    public ObjectLog()
    {
        Data = default;
        Message = "";
        Success = false;
    }
    
    public ObjectLog(T? data)
    {
        Data = data;
        Message = "";
        Success = false;
    }
}