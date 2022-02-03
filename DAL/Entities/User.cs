namespace DAL.Entities;

public class User
{
    public long Id { get; set; }

    public string Login { get; set; }

    public string HashPassword { get; set; }
}