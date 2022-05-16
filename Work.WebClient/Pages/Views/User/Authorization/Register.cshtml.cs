using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient.Pages.Views.User.Authorization
{
    public class RegisterModel : PageModel
    {
        private IUserManager _userManager;

        public RegisterModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostRegister(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Authorization/Register");
                return;
            }

            var result = await _userManager.RegisterAsync(email, UserManager.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Authorization/Register");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}