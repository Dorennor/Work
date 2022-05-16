using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface IUserService
{
    Task<bool> RegisterAsync(UserModel userModel);

    Task<bool> AddAdministratorAsync(UserModel userModel);

    Task<bool> AddManagerAsync(UserModel userModel);

    Task<bool> AddUserAsync(UserModel userModel);

    Task<bool> LoginAsync(UserModel userModel);

    Task LogoutAsync(UserModel userModel);
    Task DeleteUserAsync(int id);
    Task<List<UserModel>> GetUsersAsync();

    Task<UserModel?> GetLoggedUserAsync();
}