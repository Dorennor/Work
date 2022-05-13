using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class HotelTicketsRepository : IRepository<HotelTicket>
{
    private readonly TourDbContext _context;

    public HotelTicketsRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HotelTicket>> GetAllAsync()
    {
        try
        {
            var obj = _context.HotelTickets.ToList();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<HotelTicket> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.HotelTickets.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (Obj != null) return Obj;
                else return null;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<HotelTicket>> FindAsync(Func<HotelTicket, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.HotelTickets.Where(predicate).ToList();
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<HotelTicket> CreateAsync(HotelTicket hotelTicket)
    {
        try
        {
            if (hotelTicket != null)
            {
                var obj = await _context.HotelTickets.AddAsync(hotelTicket);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateAsync(HotelTicket hotelTicket)
    {
        try
        {
            if (hotelTicket != null)
            {
                var obj = _context.HotelTickets.Update(hotelTicket);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(HotelTicket hotelTicket)
    {
        try
        {
            if (hotelTicket != null)
            {
                var obj = _context.HotelTickets.Remove(hotelTicket);
                if (obj != null)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}