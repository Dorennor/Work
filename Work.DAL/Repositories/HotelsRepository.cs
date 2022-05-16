using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class HotelsRepository : IRepository<Hotel>
{
    private readonly TourDbContext _context;

    public HotelsRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAllAsync()
    {
        try
        {
            var obj = await _context.Hotels.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Hotel> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Hotels.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<Hotel>> FindAsync(Func<Hotel, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Hotels.Where(predicate).ToList();
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

    public async Task<Hotel> CreateAsync(Hotel hotel)
    {
        try
        {
            if (hotel != null)
            {
                var obj = await _context.Hotels.AddAsync(hotel);
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

    public async Task UpdateAsync(Hotel hotel)
    {
        try
        {
            if (hotel != null)
            {
                var obj = _context.Hotels.Update(hotel);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(Hotel hotel)
    {
        try
        {
            if (hotel != null)
            {
                var obj = _context.Hotels.Remove(hotel);
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