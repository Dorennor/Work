using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Work.WebClient.Models;

namespace Work.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private static HttpClient _client;
        public List<TourViewModel> Tours { get; set; }

        public IndexModel()
        {
            _client = new HttpClient();
        }

        public async Task OnGet()
        {
            try
            {
                Tours = await _client.GetFromJsonAsync<List<TourViewModel>>(new Uri("http://localhost:60425/api/getTours"));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}