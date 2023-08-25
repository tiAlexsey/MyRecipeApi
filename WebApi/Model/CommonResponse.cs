namespace WebApi.Model;

public class CommonResponse
{
    public object? Item { get; }
    public string Message { get; }
    public int Total { get; }

    public CommonResponse(object item, int total = 1, string message = "")
    {
        Item = item;
        Total = total;
        Message = message;
    }

    public CommonResponse(object item, string message)
    {
        Item = item;
        Message = message;
    }

    public CommonResponse(string message)
    {
        Message = message;
    }
}