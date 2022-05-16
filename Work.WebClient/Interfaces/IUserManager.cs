using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface IUserManager
{
    UserViewModel? LoggedUser { get; }

    Task<bool> LoginAsync(string email, string passwordHash);

    Task<bool> RegisterAsync(string email, string passwordHash);

    Task<bool> AddAdministratorAsync(string email, string passwordHash);

    Task<bool> AddManagerAsync(string email, string passwordHash);

    Task<bool> AddUserAsync(string email, string passwordHash);
    Task<bool> DeleteUserAsync(int id);

    Task LogoutAsync();
}