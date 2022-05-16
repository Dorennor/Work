using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface ITourService
{
    Task<TourModel> GetTourById(int id);

    Task<List<TourModel>> GetAllTours();

    Task AddTourAsync(TourModel tourModel);

    Task EditTourAsync(TourModel tourModel);

    Task DeleteTourAsync(int id);
}