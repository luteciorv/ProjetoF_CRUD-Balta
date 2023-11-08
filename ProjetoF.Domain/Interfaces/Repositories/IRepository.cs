﻿using ProjetoF.Domain.Entities;

namespace AspNet_RazorPages.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
