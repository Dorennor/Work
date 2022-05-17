using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface ITransportService
{
    Task<TransportViewModel> GetTransportByIdAsync(int id);

    Task<List<TransportViewModel>> GetAllTransports();

    Task AddTransportAsync(TransportViewModel transportViewModel);

    Task EditTransportAsync(TransportViewModel transportViewModel);

    Task DeleteTransportAsync(int id);
}