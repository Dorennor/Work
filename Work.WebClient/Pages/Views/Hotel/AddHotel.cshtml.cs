using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Hotel
{
    public class AddHotelModel : PageModel
    {
        private IHotelService _hotelManager;

        public AddHotelModel(IHotelService hotelManager)
        {
            _hotelManager = hotelManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddHotelAsync(string name, int stars, double price)
        {
            if (name == null || stars == null || price == null)
            {
                Response.Redirect("/Views/Hotel/AddHotel");
                return;
            }

            await _hotelManager.AddHotelAsync(new HotelViewModel
            {
                HotelName = name,
                HotelPrice = price,
                HotelStars = stars
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}