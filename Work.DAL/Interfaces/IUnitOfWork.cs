using Microsoft.AspNetCore.Identity;
using Work.DAL.Entities;

namespace Work.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Tour> Tours { get; set; }
    IRepository<IdentityUser<int>> Users { get; set; }
    IRepository<Order> Orders { get; set; }
    IRepository<HotelTicket> HotelTickets { get; set; }
    IRepository<Hotel> Hotels { get; set; }
    IRepository<TransportTicket> TransportTickets { get; set; }
    IRepository<Transport> Transports { get; set; }

    Task SaveAsync();
}