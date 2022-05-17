using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface IHotelService
{
    Task<HotelModel> GetHotelByIdAsync(int id);

    Task<List<HotelModel>> GetAllHotelsAsync();

    Task AddHotelAsync(HotelModel hotelModel);

    Task EditHotelAsync(HotelModel hotelModel);

    Task DeleteHotelAsync(int id);
}