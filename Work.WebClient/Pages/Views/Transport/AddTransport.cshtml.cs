using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Transport
{
    public class AddTransportModel : PageModel
    {
        private ITransportService _transportManager;

        public AddTransportModel(ITransportService transportManager)
        {
            _transportManager = transportManager;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAddTransportAsync(string name, double price)
        {
            if (name == null || price == null)
            {
                Response.Redirect("/Views/Transport/DeleteTransport");
                return;
            }

            await _transportManager.AddTransportAsync(new TransportViewModel
            {
                Name = name,
                TransportPrice = price
            });

            Response.Redirect("/Views/Home/Index");
        }
    }
}