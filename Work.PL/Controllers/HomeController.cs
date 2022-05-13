using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransportService _transportService;

        public HomeController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        [Route("getTransport")]
        public async Task<ActionResult<TransportModel>> GetTransportByIdAsync(int id)
        {
            var transport = await _transportService.GetTransportByIdAsync(id);

            if (transport == null)
            {
                return NotFound("ERROR 404");
            }

            return transport;
        }

        [HttpPost]
        [Route("addTransport")]
        public async Task AddTransportAsync(TransportModel transportModel)
        {
            await _transportService.AddTransport(transportModel);
        }
    }
}