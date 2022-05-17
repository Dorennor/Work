using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class HotelTicketsController : Controller
    {
        private readonly IHotelTicketService _hotelTicketService;

        public HotelTicketsController(IHotelTicketService hotelTicketService)
        {
            _hotelTicketService = hotelTicketService;
        }

        [HttpGet]
        [Route("api/getHotelTickets")]
        public async Task<List<HotelTicketModel>> GetAllHotelTicketsAsync()
        {
            return await _hotelTicketService.GetAllHotelTicketsAsync();
        }

        [HttpGet]
        [Route("api/getHotelTicket")]
        public async Task<HotelTicketModel> GetHotelTicketAsync(int id)
        {
            return await _hotelTicketService.GetHotelTicketByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addHotelTicket")]
        public async Task AddHotelTicketAsync([FromBody] HotelTicketModel hotelTicketModel)
        {
            if (hotelTicketModel == null) return;
            await _hotelTicketService.AddHotelTicketAsync(hotelTicketModel);
        }

        [HttpPost]
        [Route("api/deleteHotelTicket")]
        public async Task DeleteHotelTicketAsync([FromBody] int id)
        {
            if (id == null) return;
            await _hotelTicketService.DeleteHotelTicketAsync(id);
        }

        [HttpPost]
        [Route("api/editHotelTicket")]
        public async Task EditHotelTicketAsync([FromBody] HotelTicketModel hotelTicketModel)
        {
            if (hotelTicketModel == null) return;
            await _hotelTicketService.EditHotelTicketAsync(hotelTicketModel);
        }
    }
}