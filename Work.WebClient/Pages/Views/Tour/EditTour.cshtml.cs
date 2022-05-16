using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Tour
{
    public class EditTourModel : PageModel
    {
        private ITourService _tourService;

        public int Id { get; set; }

        public EditTourModel(ITourService tourService)
        {
            _tourService = tourService;
        }

        public void OnGet(int id)
        {
            Id = id;
        }

        public async Task OnPostEditTourAsync(int id, string tourName, string tourType, string tourRegion, string tourMovementType, DateTime tourDate, int duration)
        {
            if (id == null || tourName == null || tourType == null || tourRegion == null || tourMovementType == null || tourDate == null || duration == null)
            {
                Response.Redirect("/Views/Home/Index");
                return;
            }

            await _tourService.EditTourAsync(new TourViewModel
            {
                Id = id,
                TourName = tourName,
                TourType = tourType,
                TourRegion = tourRegion,
                TourMovementType = tourMovementType,
                TourDateTime = tourDate,
                TourDurationInDays = duration
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}