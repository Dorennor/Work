﻿namespace Work.DAL.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<List<T>> FindAsync(Func<T, bool> predicate);

    Task<T> CreateAsync(T item);

    Task UpdateAsync(T item);

    Task DeleteAsync(T item);
}