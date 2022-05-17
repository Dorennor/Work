using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class TransportTicketService : ITransportTicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _transportTicketMapper;

    public TransportTicketService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<TransportTicket, TransportTicketModel>().ReverseMap());
        _transportTicketMapper = new Mapper(config);
    }

    public async Task<TransportTicketModel> GetTransportTicketByIdAsync(int id)
    {
        var transportTicket = await _unitOfWork.TransportTickets.GetByIdAsync(id);
        var transportTicketModel = _transportTicketMapper.Map<TransportTicket, TransportTicketModel>(transportTicket);
        return transportTicketModel;
    }

    public async Task<List<TransportTicketModel>> GetAllTransportTicketsAsync()
    {
        var transportTickets = await _unitOfWork.TransportTickets.GetAllAsync();
        var transportTicketsModels = _transportTicketMapper.Map<List<TransportTicket>, List<TransportTicketModel>>(transportTickets);

        return transportTicketsModels;
    }

    public async Task AddTransportTicketAsync(TransportTicketModel transportTicketModel)
    {
        var transportTicket = _transportTicketMapper.Map<TransportTicketModel, TransportTicket>(transportTicketModel);
        await _unitOfWork.TransportTickets.CreateAsync(transportTicket);
    }

    public async Task EditTransportTicketAsync(TransportTicketModel transportTicketModel)
    {
        var transportTicket = _transportTicketMapper.Map<TransportTicketModel, TransportTicket>(transportTicketModel);
        await _unitOfWork.TransportTickets.UpdateAsync(transportTicket);
    }

    public async Task DeleteTransportTicketAsync(int id)
    {
        var transportTicketList = await _unitOfWork.TransportTickets.FindAsync(t => t.Id == id);
        var transportTicket = transportTicketList.First();
        await _unitOfWork.TransportTickets.DeleteAsync(transportTicket);
    }
}