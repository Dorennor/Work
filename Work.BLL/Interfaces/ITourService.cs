using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface ITourService
{
    Task<TourModel> GetTourByIdAsync(int id);

    Task<List<TourModel>> GetAllToursAsync();

    Task AddTourAsync(TourModel tourModel);

    Task EditTourAsync(TourModel tourModel);

    Task DeleteTourAsync(int id);
}