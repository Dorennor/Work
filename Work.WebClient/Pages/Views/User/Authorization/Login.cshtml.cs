using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient.Pages.Views.User.Authorization
{
    public class LoginModel : PageModel
    {
        private IUserManager _userManager;

        public LoginModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostLogin(string email, string password)
        {
            if (email == null || password == null)
            {
                Response.Redirect("/Views/User/Authorization/Login");
                return;
            }

            var result = await _userManager.LoginAsync(email, UserManager.GeneratePasswordHash(password));

            Log.Information(result.ToString());

            if (!result)
            {
                Response.Redirect("/Views/User/Authorization/Login");
                return;
            }

            Response.Redirect("/Views/Home/Index");
        }
    }
}