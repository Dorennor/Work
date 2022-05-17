using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _hotelMapper;

    public HotelService()
    {
        _unitOfWork = new UnitOfWork();

        var config = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, HotelModel>().ReverseMap());
        _hotelMapper = new Mapper(config);
    }

    public async Task<HotelModel> GetHotelByIdAsync(int id)
    {
        var hotel = await _unitOfWork.Hotels.GetByIdAsync(id);
        var hotelModel = _hotelMapper.Map<Hotel, HotelModel>(hotel);
        return hotelModel;
    }

    public async Task<List<HotelModel>> GetAllHotelsAsync()
    {
        var hotels = await _unitOfWork.Hotels.GetAllAsync();
        var hotelsModels = _hotelMapper.Map<List<Hotel>, List<HotelModel>>(hotels);

        return hotelsModels;
    }

    public async Task AddHotelAsync(HotelModel hotelModel)
    {
        var hotel = _hotelMapper.Map<HotelModel, Hotel>(hotelModel);
        await _unitOfWork.Hotels.CreateAsync(hotel);
    }

    public async Task EditHotelAsync(HotelModel hotelModel)
    {
        var hotel = _hotelMapper.Map<HotelModel, Hotel>(hotelModel);
        await _unitOfWork.Hotels.UpdateAsync(hotel);
    }

    public async Task DeleteHotelAsync(int id)
    {
        var hotelsList = await _unitOfWork.Hotels.FindAsync(t => t.Id == id);
        var hotel = hotelsList.First();
        await _unitOfWork.Hotels.DeleteAsync(hotel);
    }
}