using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Transport
{
    public class DeleteTransportModel : PageModel
    {
        private ITransportService _transportService;
        public List<TransportViewModel> Transports { get; set; }

        public DeleteTransportModel(ITransportService transportService)
        {
            _transportService = transportService;
            Transports = _transportService.GetAllTransports().Result;
        }

        public async Task OnGetAsync()
        {
            Transports = await _transportService.GetAllTransports();
        }

        public async Task OnPostDeleteTransportAsync(int id)
        {
            await _transportService.DeleteTransportAsync(id);
            Response.Redirect("/Views/Home/Index");
        }
    }
}