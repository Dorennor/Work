using Microsoft.AspNetCore.Mvc.RazorPages;
using Work.WebClient.Interfaces;
using Work.WebClient.Models;

namespace Work.WebClient.Pages.Views.Order
{
    public class DeleteModel : PageModel
    {
        private IOrderService _orderService;
        public List<OrderViewModel> Orders { get; set; }

        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
            Orders = _orderService.GetAllOrders().Result;
        }

        public async Task OnGetAsync()
        {
            Orders = await _orderService.GetAllOrders();
        }

        public async Task OnPostDeleteOrderAsync(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            Response.Redirect("/Views/Home/Index");
        }
    }
}