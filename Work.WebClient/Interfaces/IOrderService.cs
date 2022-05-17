using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface IOrderService
{
    Task<OrderViewModel> GetOrderByIdAsync(int id);

    Task<List<OrderViewModel>> GetAllOrders();

    Task AddOrderAsync(OrderViewModel orderViewModel);

    Task EditOrderAsync(OrderViewModel orderViewModel);

    Task DeleteOrderAsync(int id);
}