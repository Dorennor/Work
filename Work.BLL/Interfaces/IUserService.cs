using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface IUserService
{
    Task<bool> AddUserAsync(UserModel userModel);

    Task<bool> LoginAsync(UserModel userModel);

    Task LogoutAsync(UserModel userModel);

    Task DeleteUserAsync(int id);

    Task<List<UserModel>> GetUsersAsync();

    Task<UserModel?> GetLoggedUserAsync();
}