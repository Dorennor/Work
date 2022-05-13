using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class ToursRepository : IRepository<Tour>
{
    private readonly TourDbContext _context;

    public ToursRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tour>> GetAllAsync()
    {
        try
        {
            var obj = _context.Tours.ToList();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Tour> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Tours.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<IEnumerable<Tour>> FindAsync(Func<Tour, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Tours.Where(predicate).ToList();
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

    public async Task<Tour> CreateAsync(Tour tour)
    {
        try
        {
            if (tour != null)
            {
                var obj = await _context.Tours.AddAsync(tour);
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

    public async Task UpdateAsync(Tour tour)
    {
        try
        {
            if (tour != null)
            {
                var obj = _context.Tours.Update(tour);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(Tour tour)
    {
        try
        {
            if (tour != null)
            {
                var obj = _context.Tours.Remove(tour);
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