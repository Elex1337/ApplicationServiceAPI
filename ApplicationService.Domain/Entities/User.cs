namespace ApplicationService.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}