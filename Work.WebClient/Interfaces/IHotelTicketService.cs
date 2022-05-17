using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface IHotelTicketService
{
    Task<HotelTicketViewModel> GetHotelTicketByIdAsync(int id);

    Task<List<HotelTicketViewModel>> GetAllHotelTickets();

    Task AddHotelTicketAsync(HotelTicketViewModel hotelTicketViewModel);

    Task EditHotelTicketAsync(HotelTicketViewModel hotelTicketViewModel);

    Task DeleteHotelTicketAsync(int id);
}