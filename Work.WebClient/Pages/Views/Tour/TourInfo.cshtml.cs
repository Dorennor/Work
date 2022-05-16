using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Tour
{
    public class TourInfo : PageModel
    {
        private ITourService _tourService;
        public TourViewModel TourViewModel { get; set; }

        public TourInfo(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task OnGetAsync(int id)
        {
            TourViewModel = await _tourService.GetTourAsync(id);
        }
    }
}