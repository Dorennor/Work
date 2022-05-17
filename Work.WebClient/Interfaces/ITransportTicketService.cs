using Work.WebClient.Models;

namespace Work.WebClient.Interfaces;

public interface ITransportTicketService
{
    Task<TransportTicketViewModel> GetTransportTicketTicketByIdAsync(int id);

    Task<List<TransportTicketViewModel>> GetAllTransportTicketTickets();

    Task AddTransportTicketAsync(TransportTicketViewModel transportTicketViewModel);

    Task EditTransportTicketAsync(TransportTicketViewModel transportTicketViewModel);

    Task DeleteTransportTicketAsync(int id);
}