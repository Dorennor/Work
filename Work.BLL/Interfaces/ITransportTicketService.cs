using Work.BLL.Models;

namespace Work.BLL.Interfaces;

public interface ITransportTicketService
{
    Task<TransportTicketModel> GetTransportTicketByIdAsync(int id);

    Task<List<TransportTicketModel>> GetAllTransportTicketsAsync();

    Task AddTransportTicketAsync(TransportTicketModel transportTicketModel);

    Task EditTransportTicketAsync(TransportTicketModel transportTicketModel);

    Task DeleteTransportTicketAsync(int id);
}