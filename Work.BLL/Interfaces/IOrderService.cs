using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface IOrderService
{
    Task<OrderModel> GetOrderByIdAsync(int id);

    Task<List<OrderModel>> GetAllOrdersAsync();

    Task AddOrderAsync(OrderModel orderModel);

    Task EditOrderAsync(OrderModel orderModel);

    Task DeleteOrderAsync(int id);
}