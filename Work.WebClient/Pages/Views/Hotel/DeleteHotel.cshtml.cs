using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Hotel
{
    public class DeleteHotelModel : PageModel
    {
        private IHotelService _hotelService;
        public List<HotelViewModel> Hotels { get; set; }

        public DeleteHotelModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
            Hotels = _hotelService.GetAllHotels().Result;
        }

        public async Task OnGetAsync()
        {
            Hotels = await _hotelService.GetAllHotels();
        }

        public async Task OnPostDeleteHotelAsync(int id)
        {
            await _hotelService.DeleteHotelAsync(id);
            Response.Redirect("/Views/Home/Index");
        }
    }
}