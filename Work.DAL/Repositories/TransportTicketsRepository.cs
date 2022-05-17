﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class TransportTicketsRepository : IRepository<TransportTicket>
{
    private readonly TourDbContext _context;

    public TransportTicketsRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<List<TransportTicket>> GetAllAsync()
    {
        try
        {
            var obj = await _context.TransportTickets.ToListAsync();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<TransportTicket> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.TransportTickets.Where(u => u.Id == id).FirstOrDefaultAsync();
                if (Obj != null) return Obj;
                else return null;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<List<TransportTicket>> FindAsync(Func<TransportTicket, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.TransportTickets.Where(predicate).ToList();
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task<TransportTicket> CreateAsync(TransportTicket transportTicket)
    {
        try
        {
            if (transportTicket != null)
            {
                var obj = await _context.TransportTickets.AddAsync(transportTicket);
                await _context.SaveChangesAsync();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
            return null;
        }
    }

    public async Task UpdateAsync(TransportTicket transportTicket)
    {
        try
        {
            if (transportTicket != null)
            {
                var obj = _context.TransportTickets.Update(transportTicket);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }

    public async Task DeleteAsync(TransportTicket transportTicket)
    {
        try
        {
            if (transportTicket != null)
            {
                var obj = _context.TransportTickets.Remove(transportTicket);
                if (obj != null)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
        catch (Exception e)
        {
            Log.Information(e.ToString());
        }
    }
}