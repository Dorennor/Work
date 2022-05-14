using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Models;

namespace Work.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private static HttpClient _client;
        private List<TourViewModel> Tours;
        public List<TourViewModel> DisplayedTours { get; set; }

        public IndexModel()
        {
            _client = new HttpClient();
            Tours = _client.GetFromJsonAsync<List<TourViewModel>>(new Uri("http://localhost:60425/api/getTours")).Result!;
        }

        public void OnGet()
        {
            DisplayedTours = Tours;
        }

        public void OnPostById(int id)
        {
            DisplayedTours = Tours.Where(t => t.Id > id).ToList();
        }
    }
}