using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class TransportTicketsController : Controller
    {
        private readonly ITransportTicketService _transportTicketService;

        public TransportTicketsController(ITransportTicketService transportTicketService)
        {
            _transportTicketService = transportTicketService;
        }

        [HttpGet]
        [Route("api/getTransportTickets")]
        public async Task<List<TransportTicketModel>> GetAllTransportTicketsAsync()
        {
            return await _transportTicketService.GetAllTransportTicketsAsync();
        }

        [HttpGet]
        [Route("api/getTransportTicket")]
        public async Task<TransportTicketModel> GetTransportTicketAsync(int id)
        {
            return await _transportTicketService.GetTransportTicketByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addTransportTicket")]
        public async Task AddTransportTicketAsync([FromBody] TransportTicketModel transportTicketModel)
        {
            if (transportTicketModel == null) return;
            await _transportTicketService.AddTransportTicketAsync(transportTicketModel);
        }

        [HttpPost]
        [Route("api/deleteTransportTicket")]
        public async Task DeleteTransportTicketAsync(int id)
        {
            if (id == null) return;
            await _transportTicketService.DeleteTransportTicketAsync(id);
        }

        [HttpPost]
        [Route("api/editTransportTicket")]
        public async Task EditTransportTicketAsync([FromBody] TransportTicketModel transportTicketModel)
        {
            if (transportTicketModel == null) return;
            await _transportTicketService.EditTransportTicketAsync(transportTicketModel);
        }
    }
}