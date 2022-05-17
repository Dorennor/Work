using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Tour
{
    public class AddTourModel : PageModel
    {
        private ITourService _tourService;

        public AddTourModel(ITourService tourService)
        {
            _tourService = tourService;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddTourAsync(string tourName, string tourType, string tourRegion, string tourMovementType, DateTime tourDate, int duration, double price)
        {
            if (tourName == null || tourType == null || tourRegion == null || tourMovementType == null || tourDate == null || duration == null || price == null)
            {
                Response.Redirect("/Views/Tour/AddTour");
                return;
            }

            await _tourService.AddTourAsync(new TourViewModel
            {
                TourName = tourName,
                TourType = tourType,
                TourRegion = tourRegion,
                TourMovementType = tourMovementType,
                TourDateTime = tourDate,
                TourDurationInDays = duration,
                TourPrice = price
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}