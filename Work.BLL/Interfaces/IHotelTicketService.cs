using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface IHotelTicketService
{
    Task<HotelTicketModel> GetHotelTicketByIdAsync(int id);

    Task<List<HotelTicketModel>> GetAllHotelTicketsAsync();

    Task AddHotelTicketAsync(HotelTicketModel hotelTicketModel);

    Task EditHotelTicketAsync(HotelTicketModel hotelTicketModel);

    Task DeleteHotelTicketAsync(int id);
}