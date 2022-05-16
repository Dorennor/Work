using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;

namespace Work.WebClient.Pages.Views.Tour
{
    public class DeleteTourModel : PageModel
    {
        private ITourService _tourService;

        public DeleteTourModel(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task OnGetAsync(int id)
        {
            if (id == null)
            {
                Response.Redirect("/Views/Home/Index");
                return;
            }

            await _tourService.DeleteTourAsync(id);
        }
    }
}