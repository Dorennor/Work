using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class TransportsController : Controller
    {
        private readonly ITransportService _transportService;

        public TransportsController(ITransportService transportService)
        {
            _transportService = transportService;
        }

        [HttpGet]
        [Route("api/getTransports")]
        public async Task<List<TransportModel>> GetAllTransportsAsync()
        {
            return await _transportService.GetAllTransportsAsync();
        }

        [HttpGet]
        [Route("api/getTransport")]
        public async Task<TransportModel> GetTransportAsync(int id)
        {
            return await _transportService.GetTransportByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addTransport")]
        public async Task AddTransportAsync([FromBody] TransportModel transportModel)
        {
            if (transportModel == null) return;
            await _transportService.AddTransportAsync(transportModel);
        }

        [HttpPost]
        [Route("api/deleteTransport")]
        public async Task DeleteTransportAsync([FromBody] int id)
        {
            if (id == null) return;
            await _transportService.DeleteTransportAsync(id);
        }

        [HttpPost]
        [Route("api/editTransport")]
        public async Task EditTransportAsync([FromBody] TransportModel transportModel)
        {
            if (transportModel == null) return;
            await _transportService.EditTransportAsync(transportModel);
        }
    }
}