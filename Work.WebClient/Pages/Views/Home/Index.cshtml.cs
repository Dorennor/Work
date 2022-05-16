using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Home
{
    public class IndexModel : PageModel
    {
        
        private IUserManagerService _userManager;
        public List<TourViewModel> Tours { get; set; }

        public IndexModel(IUserManagerService userManager)
        {
            _userManager = userManager;

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60425/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Tours = httpClient.GetFromJsonAsync<List<TourViewModel>>("api/getTours").Result!;
        }

        public void OnGet(bool logout = false)
        {
            if (logout)
            {
                _userManager.LogoutAsync();
                Response.Redirect("/Views/Home/Index");
            }
        }
    }
}