using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("api/getHotels")]
        public async Task<List<HotelModel>> GetAllHotelsAsync()
        {
            return await _hotelService.GetAllHotelsAsync();
        }

        [HttpGet]
        [Route("api/getHotel")]
        public async Task<HotelModel> GetHotelAsync(int id)
        {
            return await _hotelService.GetHotelByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addHotel")]
        public async Task AddHotelAsync([FromBody] HotelModel hotelModel)
        {
            if (hotelModel == null) return;
            await _hotelService.AddHotelAsync(hotelModel);
        }

        [HttpPost]
        [Route("api/deleteHotel")]
        public async Task DeleteHotelAsync(int id)
        {
            if (id == null) return;
            await _hotelService.DeleteHotelAsync(id);
        }

        [HttpPost]
        [Route("api/editHotel")]
        public async Task EditHotelAsync([FromBody] HotelModel hotelModel)
        {
            if (hotelModel == null) return;
            await _hotelService.EditHotelAsync(hotelModel);
        }
    }
}