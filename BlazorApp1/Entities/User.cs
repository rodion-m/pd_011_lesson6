namespace BlazorApp1.Entities;

public class User
{
    public static User CurrentUser = new User()
    {
        Id = new Guid("E8EF2B13-1291-4346-AA44-BDAD9DF218F4")
    };

    //public Guid CartId { get; set; }
    public Guid Id { get; set; }
}