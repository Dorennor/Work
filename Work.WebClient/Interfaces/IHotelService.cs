using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface IHotelService
{
    Task<HotelViewModel> GetHotelByIdAsync(int id);

    Task<List<HotelViewModel>> GetAllHotels();

    Task AddHotelAsync(HotelViewModel hotelViewModel);

    Task EditHotelAsync(HotelViewModel hotelViewModel);

    Task DeleteHotelAsync(int id);
}