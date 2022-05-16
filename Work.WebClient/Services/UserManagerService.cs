using Serilog;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Services;

public class UserManagerService : IUserManagerService
{
    private UserViewModel? _loggedUser;

    public UserManagerService()
    {
        var httpClient = new HttpClient();

        httpClient.BaseAddress = new Uri("http://localhost:60425/");
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            var loggedUser = httpClient.GetFromJsonAsync<UserViewModel?>("api/getLoggedUser").Result;
        }
        catch (Exception e)
        {
        }
    }

    public UserViewModel? LoggedUser
    {
        get
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var loggedUser = httpClient.GetFromJsonAsync<UserViewModel>("api/getLoggedUser").Result;
                return loggedUser;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public async Task<bool> LoginAsync(string email, string passwordHash)
    {
        try
        {
            if (email != null && passwordHash != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new UserViewModel
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    IsLogged = true
                };

                var result = await httpClient.PostAsJsonAsync("api/login", user);

                Log.Information($"UserManager {result.IsSuccessStatusCode}");

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> RegisterAsync(string email, string passwordHash)
    {
        try
        {
            if (email != null && passwordHash != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new UserViewModel
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = "User",
                    IsLogged = true
                };

                var result = await httpClient.PostAsJsonAsync("api/register", user);

                Log.Information($"UserManager {result.IsSuccessStatusCode}");

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> AddAdministratorAsync(string email, string passwordHash)
    {
        try
        {
            if (email != null && passwordHash != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var administrator = new UserViewModel
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = "Administrator",
                    IsLogged = false
                };

                var result = await httpClient.PostAsJsonAsync("api/addAdministrator", administrator);

                Log.Information($"UserManager {result.IsSuccessStatusCode}");

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> AddManagerAsync(string email, string passwordHash)
    {
        try
        {
            if (email != null && passwordHash != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var manager = new UserViewModel
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = "Manager",
                    IsLogged = false
                };

                var result = await httpClient.PostAsJsonAsync("api/addManager", manager);

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> AddUserAsync(string email, string passwordHash)
    {
        try
        {
            if (email != null && passwordHash != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new UserViewModel
                {
                    Email = email,
                    PasswordHash = passwordHash,
                    Role = "User",
                    IsLogged = false
                };

                var result = await httpClient.PostAsJsonAsync("api/addUser", user);

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        try
        {
            if (id != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await httpClient.PostAsJsonAsync("api/deleteUser", id);

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception e)
        {
            return false;
        }

        return false;
    }

    public async Task LogoutAsync()
    {
        try
        {
            if (LoggedUser != null)
            {
                using var httpClient = new HttpClient();

                httpClient.BaseAddress = new Uri("http://localhost:60425/");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                LoggedUser.IsLogged = false;

                await httpClient.PostAsJsonAsync("api/logout", LoggedUser);
            }
        }
        catch (Exception e)
        {
        }
    }

    public static string GeneratePasswordHash(string password)
    {
        using (var sha512 = SHA512.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hashCode = sha512.ComputeHash(bytes);
            return BitConverter.ToString(hashCode);
        }
    }
}