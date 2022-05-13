﻿using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Entities;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class OrdersRepository : IRepository<Order>
{
    private readonly TourDbContext _context;

    public OrdersRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        try
        {
            var obj = _context.Orders.ToList();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Orders.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<IEnumerable<Order>> FindAsync(Func<Order, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Orders.Where(predicate).ToList();
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

    public async Task<Order> CreateAsync(Order order)
    {
        try
        {
            if (order != null)
            {
                var obj = await _context.Orders.AddAsync(order);
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

    public async Task UpdateAsync(Order order)
    {
        try
        {
            if (order != null)
            {
                var obj = _context.Orders.Update(order);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(Order order)
    {
        try
        {
            if (order != null)
            {
                var obj = _context.Orders.Remove(order);
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