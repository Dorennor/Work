using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface ITransportService
{
    Task<TransportModel> GetTransportByIdAsync(int id);

    Task AddTransport(TransportModel transportModel);
}