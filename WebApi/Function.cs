namespace WebApi;

public static class Function
{
    public static string Response(bool response)
    {
        return response ? "Success" : "Fail";
    }
}