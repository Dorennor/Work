﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Work.DAL.Data;
using Work.DAL.Interfaces;

namespace Work.DAL.Repositories;

public class UsersRepository : IRepository<IdentityUser<int>>
{
    private readonly TourDbContext _context;

    public UsersRepository(TourDbContext context)
    {
        _context = context;
    }

    public async Task<List<IdentityUser<int>>> GetAllAsync()
    {
        try
        {
            var obj = _context.Users.ToList();
            if (obj != null) return obj;
            else return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IdentityUser<int>> GetByIdAsync(int id)
    {
        try
        {
            if (id != null)
            {
                var Obj = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
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

    public async Task<List<IdentityUser<int>>> FindAsync(Func<IdentityUser<int>, bool> predicate)
    {
        try
        {
            if (predicate != null)
            {
                return _context.Users.Where(predicate).ToList();
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

    public async Task<IdentityUser<int>> CreateAsync(IdentityUser<int> user)
    {
        try
        {
            if (user != null)
            {
                var obj = await _context.Users.AddAsync(user);
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

    public async Task UpdateAsync(IdentityUser<int> user)
    {
        try
        {
            if (user != null)
            {
                var obj = _context.Users.Update(user);
                if (obj != null) await _context.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteAsync(IdentityUser<int> user)
    {
        try
        {
            if (user != null)
            {
                var obj = _context.Users.Remove(user);
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