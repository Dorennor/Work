using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _orderMapper;

    public OrderService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>().ReverseMap());
        _orderMapper = new Mapper(config);
    }

    public async Task<OrderModel> GetOrderByIdAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        var orderModel = _orderMapper.Map<Order, OrderModel>(order);
        return orderModel;
    }

    public async Task<List<OrderModel>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        var orderModels = _orderMapper.Map<List<Order>, List<OrderModel>>(orders);

        return orderModels;
    }

    public async Task AddOrderAsync(OrderModel orderModel)
    {
        var order = _orderMapper.Map<OrderModel, Order>(orderModel);
        await _unitOfWork.Orders.CreateAsync(order);
    }

    public async Task EditOrderAsync(OrderModel orderModel)
    {
        var order = _orderMapper.Map<OrderModel, Order>(orderModel);
        await _unitOfWork.Orders.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        var orderList = await _unitOfWork.Orders.FindAsync(t => t.Id == id);
        var order = orderList.First();
        await _unitOfWork.Orders.DeleteAsync(order);
    }
}