﻿using AspNet_RazorPages.Data;
using AspNet_RazorPages.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AspNet_RazorPages.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(DataContext context, ILogger<Repository<TEntity>> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task AddAsync(TEntity entity) =>
            await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity) =>
            _context.Set<TEntity>().Remove(entity);

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Não foi possível persistir os dados no banco de dados. Exceção: {ex.Message}", ex);
            }
        }
    }
}
