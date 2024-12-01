﻿
using Microsoft.EntityFrameworkCore;
using PassportWebApplication.Data;
using PassportWebApplication.Repository.IRepository;

namespace ContessoUniversity.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PassportContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(PassportContext context) 
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();   
        }
    }
}
