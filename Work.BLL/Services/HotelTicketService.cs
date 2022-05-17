using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class HotelTicketService : IHotelTicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _hotelTicketMapper;

    public HotelTicketService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<HotelTicket, HotelTicketModel>().ReverseMap());
        _hotelTicketMapper = new Mapper(config);
    }

    public async Task<HotelTicketModel> GetHotelTicketByIdAsync(int id)
    {
        var hotelTicket = await _unitOfWork.HotelTickets.GetByIdAsync(id);
        var hotelTicketModel = _hotelTicketMapper.Map<HotelTicket, HotelTicketModel>(hotelTicket);
        return hotelTicketModel;
    }

    public async Task<List<HotelTicketModel>> GetAllHotelTicketsAsync()
    {
        var hotelTickets = await _unitOfWork.HotelTickets.GetAllAsync();
        var hotelTicketsModels = _hotelTicketMapper.Map<List<HotelTicket>, List<HotelTicketModel>>(hotelTickets);

        return hotelTicketsModels;
    }

    public async Task AddHotelTicketAsync(HotelTicketModel hotelTicketModel)
    {
        var hotelTicket = _hotelTicketMapper.Map<HotelTicketModel, HotelTicket>(hotelTicketModel);
        await _unitOfWork.HotelTickets.CreateAsync(hotelTicket);
    }

    public async Task EditHotelTicketAsync(HotelTicketModel hotelTicketModel)
    {
        var hotelTicket = _hotelTicketMapper.Map<HotelTicketModel, HotelTicket>(hotelTicketModel);
        await _unitOfWork.HotelTickets.UpdateAsync(hotelTicket);
    }

    public async Task DeleteHotelTicketAsync(int id)
    {
        var hotelTicketList = await _unitOfWork.HotelTickets.FindAsync(t => t.Id == id);
        var hotelTicket = hotelTicketList.First();
        await _unitOfWork.HotelTickets.DeleteAsync(hotelTicket);
    }
}