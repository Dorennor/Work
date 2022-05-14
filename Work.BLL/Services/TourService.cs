using AutoMapper;
using Work.BLL.Interfaces;
using Work.BLL.Models;
using Work.DAL.Entities;
using Work.DAL.Interfaces;
using Work.DAL.Repositories;

namespace Work.BLL.Services;

public class TourService : ITourService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Mapper _tourMapper;

    public TourService()
    {
        _unitOfWork = new UnitOfWork();

        var configPerson = new MapperConfiguration(cfg => cfg.CreateMap<Tour, TourModel>().ReverseMap());
        _tourMapper = new Mapper(configPerson);
    }

    public async Task<TourModel> GetTourById(int id)
    {
        var tour = await _unitOfWork.Tours.GetByIdAsync(id);
        var tourModel = _tourMapper.Map<Tour, TourModel>(tour);
        return tourModel;
    }

    public async Task<List<TourModel>> GetAllTours()
    {
        var tours = await _unitOfWork.Tours.GetAllAsync();
        var toursModels = _tourMapper.Map<List<Tour>, List<TourModel>>(tours);

        return toursModels;
    }

    public Task AddTourAsync(TourModel tourModel)
    {
        throw new NotImplementedException();
    }

    public async Task EditTourAsync(TourModel tourModel)
    {
        await _unitOfWork.Tours.UpdateAsync(_tourMapper.Map<TourModel, Tour>(tourModel));
    }

    public async Task DeleteTourAsync(TourModel tourModel)
    {
        await _unitOfWork.Tours.DeleteAsync(_tourMapper.Map<TourModel, Tour>(tourModel));
    }
}