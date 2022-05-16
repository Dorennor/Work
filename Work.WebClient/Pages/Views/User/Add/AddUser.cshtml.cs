using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient.Pages.Views.User.Add
{
    public class AddUserModel : PageModel
    {
        private IUserManager _userManager;

        public AddUserModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddUser(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddUser");
                return;
            }

            var result = await _userManager.AddUserAsync(email, UserManager.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddUser");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}