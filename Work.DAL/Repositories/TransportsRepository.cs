using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class TransportsRepository : IRepository<Transport>
{
    private readonly TourDbContext _context;

    public TransportsRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transport>> GetAllAsync()
    {
        try
        {
            var obj = await _context.Transports.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Transport> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Transports.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<Transport>> FindAsync(Func<Transport, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Transports.Where(predicate).ToList();
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

    public async Task<Transport> CreateAsync(Transport transport)
    {
        try
        {
            if (transport != null)
            {
                var obj = await _context.Transports.AddAsync(transport);
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

    public async Task UpdateAsync(Transport transport)
    {
        try
        {
            if (transport != null)
            {
                var obj = _context.Transports.Update(transport);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(Transport transport)
    {
        try
        {
            if (transport != null)
            {
                var obj = _context.Transports.Remove(transport);
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