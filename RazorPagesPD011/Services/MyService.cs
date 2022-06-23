namespace RazorPagesPD011.Services;

public class MyService
{
    private readonly HttpClient _httpClient;

    public MyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void DoSomething()
    {
        //_httpClient.Send(); ...
        _httpClient.Dispose();
    }
}