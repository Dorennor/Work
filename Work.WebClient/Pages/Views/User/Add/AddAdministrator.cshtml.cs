using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Services;

namespace Work.WebClient.Pages.Views.User.Add
{
    public class AddAdministratorModel : PageModel
    {
        private IUserManager _userManager;

        public AddAdministratorModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddAdministrator(string email, string password, string confirmPassword)
        {
            if (email == null || password == null || confirmPassword == null || password != confirmPassword)
            {
                Response.Redirect("/Views/User/Add/AddAdministrator");
                return;
            }

            var result = await _userManager.AddAdministratorAsync(email, UserManager.GeneratePasswordHash(password));

            if (!result)
            {
                Response.Redirect("/Views/User/Add/AddAdministrator");
                return;
            }
            Response.Redirect("/Views/Home/Index", result);
        }
    }
}
