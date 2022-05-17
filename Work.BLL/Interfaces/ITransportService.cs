using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface ITransportService
{
    Task<TransportModel> GetTransportByIdAsync(int id);

    Task<List<TransportModel>> GetAllTransportsAsync();

    Task AddTransportAsync(TransportModel transportModel);

    Task EditTransportAsync(TransportModel transportViewModel);

    Task DeleteTransportAsync(int id);
}