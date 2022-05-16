using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Home
{
    public class IndexModel : PageModel
    {
        private IUserManagerService _userManager;
        private ITourService _tourService;
        public List<TourViewModel?> Tours { get; set; }

        public IndexModel(IUserManagerService userManager, ITourService tourService)
        {
            _userManager = userManager;
            _tourService = tourService;
        }

        public async Task OnGet(bool logout = false, string sort = "none")
        {
            if (logout)
            {
                await _userManager.LogoutAsync();
                Response.Redirect("/Views/Home/Index");
            }

            Tours = await _tourService.GetAllToursAsync();
            if (Tours != null)
            {
                switch (sort)
                {
                    case "name": Tours = Tours.OrderBy(t => t.TourName).ToList();
                        break;
                    case "type": Tours = Tours.OrderBy(t => t.TourType).ToList();
                        break;
                    case "region": Tours = Tours.OrderBy(t => t.TourRegion).ToList();
                        break;
                    case "movement": Tours = Tours.OrderBy(t => t.TourMovementType).ToList();
                        break;
                    case "date": Tours = Tours.OrderBy(t => t.TourDateTime).ToList();
                        break;
                    case "duration": Tours = Tours.OrderBy(t => t.TourDurationInDays).ToList();
                        break;
                    case "nameDescending":
                        Tours = Tours.OrderByDescending(t => t.TourName).ToList();
                        break;
                    case "typeDescending":
                        Tours = Tours.OrderByDescending(t => t.TourType).ToList();
                        break;
                    case "regionDescending":
                        Tours = Tours.OrderByDescending(t => t.TourRegion).ToList();
                        break;
                    case "movementDescending":
                        Tours = Tours.OrderByDescending(t => t.TourMovementType).ToList();
                        break;
                    case "dateDescending":
                        Tours = Tours.OrderByDescending(t => t.TourDateTime).ToList();
                        break;
                    case "durationDescending":
                        Tours = Tours.OrderByDescending(t => t.TourDurationInDays).ToList();
                        break;
                }
            }
        }
    }
}