using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.ViewModels;

namespace Work.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private static HttpClient _client;
        public TourViewModel? model;

        public IndexModel()
        {
            _client = new HttpClient();

             
            
        }

        public async Task OnGet()
        {
            try
            {
                model = await _client.GetFromJsonAsync<TourViewModel>(new Uri("http://localhost:60425/api/getTour?id=1"));
                Debug.WriteLine(model?.TourName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        
    }
}