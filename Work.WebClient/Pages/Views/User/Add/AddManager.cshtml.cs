using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient.Pages.Views.User.Add
{
    public class AddManagerModel : PageModel
    {
        private IUserManager _userManager;

        public AddManagerModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddManager(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddManager");
                return;
            }

            var result = await _userManager.AddManagerAsync(email, UserManager.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddManager");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}