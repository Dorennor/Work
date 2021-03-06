using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly TourDbContext _context;

    private IRepository<Tour> _tours;
    private IRepository<User> _users;
    private IRepository<Order> _orders;
    private IRepository<HotelTicket> _hotelTickets;
    private IRepository<Hotel> _hotels;
    private IRepository<TransportTicket> _transportTickets;
    private IRepository<Transport> _transports;

    public UnitOfWork()
    {
        _context = new TourDbContext();
    }

    public IRepository<Tour> Tours
    {
        get
        {
            return _tours ??= new ToursRepository(_context);
        }

        set => _tours = value;
    }

    public IRepository<User> Users
    {
        get
        {
            return _users ??= new UsersRepository(_context);
        }

        set => _users = value;
    }

    public IRepository<Order> Orders
    {
        get
        {
            return _orders ??= new OrdersRepository(_context);
        }

        set => _orders = value;
    }

    public IRepository<HotelTicket> HotelTickets
    {
        get
        {
            return _hotelTickets ??= new HotelTicketsRepository(_context);
        }

        set => _hotelTickets = value;
    }

    public IRepository<Hotel> Hotels
    {
        get
        {
            return _hotels ??= new HotelsRepository(_context);
        }

        set => _hotels = value;
    }

    public IRepository<TransportTicket> TransportTickets
    {
        get
        {
            return _transportTickets ??= new TransportTicketsRepository(_context);
        }

        set => _transportTickets = value;
    }

    public IRepository<Transport> Transports
    {
        get
        {
            return _transports ??= new TransportsRepository(_context);
        }

        set => _transports = value;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}