﻿using InventoryTracker.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryTracker.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(int offset, int limit)
        {
            return await _repository.GetAll()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetAll().CountAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            // hashcode amigo?ai complica, como isso funciona? 
            // se olho isso aqui, devo olhar na subclasse?
            var existingEntity = await _repository.GetByIdAsync(entity.GetHashCode());
            if (existingEntity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} not found");

            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} not found");

            await _repository.DeleteAsync(entity);
        }
    }
}
