namespace ConsideraDevApi.Core.Models;

public class ObjectLog<T> where T : new()
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    
    public ObjectLog()
    {
        Data = new T();
        Message = "";
        Success = false;
    }
}