namespace Work.BLL.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string NormalizedEmail { get; set; }
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
}