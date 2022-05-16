using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface ITourService
{
    Task<bool> AddTourAsync(TourViewModel tourViewModel);

    Task<bool> UpdateTourAsync(TourViewModel tourViewModel);

    Task<bool> DeleteTourAsync(int id);

    Task<TourViewModel> GetTourAsync(int id);
}