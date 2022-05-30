using Microsoft.AspNetCore.Mvc;
using Serilog;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("api/getOrders")]
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            return await _orderService.GetAllOrdersAsync();
        }

        [HttpGet]
        [Route("api/getOrder")]
        public async Task<OrderModel> GetOrderAsync(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        [Route("api/addOrder")]
        public async Task AddOrderAsync([FromBody] OrderModel orderModel)
        {
            if (orderModel == null) return;
            Log.Information($"Controller{orderModel.TransportTicketId}");
            await _orderService.AddOrderAsync(orderModel);
        }

        [HttpPost]
        [Route("api/deleteOrder")]
        public async Task DeleteOrderAsync([FromBody] int id)
        {
            if (id == null) return;
            await _orderService.DeleteOrderAsync(id);
        }

        [HttpPost]
        [Route("api/editOrder")]
        public async Task EditOrderAsync([FromBody] OrderModel orderModel)
        {
            if (orderModel == null) return;
            await _orderService.EditOrderAsync(orderModel);
        }
    }
}