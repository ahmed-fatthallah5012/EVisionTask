using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainModel
{
    public interface IRepository<TEntity>
    {
        void InsertOrUpdate(TEntity entity);
        void Remove(TEntity entity);
        void UpdateRange(IList<TEntity> entities);
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task<IList<TEntity>> GetAllAsync();

        Task<IList<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> condition = null,
            Expression<Func<TEntity, TEntity>> selector = null);

        Task<IList<TEntity2>> FindByAsync<TEntity2>(Expression<Func<TEntity2, bool>> condition = null,
            Expression<Func<TEntity2, TEntity2>> selector = null) where  TEntity2 : DomainBase;
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainBase
    {
        private readonly SystemContext _context;

        public Repository(SystemContext context) => _context = context;

        public void InsertOrUpdate(TEntity entity)
        {
            _context.ChangeTracker.TrackGraph(entity, node =>
            {
                var entry = node.Entry;
                var childEntry = (DomainBase) entry.Entity;
                entry.State = childEntry.IsNew ? EntityState.Added : EntityState.Modified;
            });
        }

        public void Remove(TEntity entity) 
            => _context.Set<TEntity>().Remove(entity);

        public void UpdateRange(IList<TEntity> entities) 
            => _context.Set<TEntity>().UpdateRange(entities);

        public async Task BeginTransactionAsync() 
            => await _context.Database.BeginTransactionAsync();

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            catch (Exception e)
            {
                await _context.Database.RollbackTransactionAsync();
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<TEntity>> GetAllAsync() 
            => await _context.Set<TEntity>().ToListAsync();

        public Task<IList<TEntity>> FindByAsync(
            Expression<Func<TEntity, bool>> condition = null, 
            Expression<Func<TEntity, TEntity>> selector = null) 
            => FindByAsync<TEntity>(condition, selector);

        public async Task<IList<TEntity2>> FindByAsync<TEntity2>(
            Expression<Func<TEntity2, bool>> condition = null, 
            Expression<Func<TEntity2, TEntity2>> selector = null) where TEntity2 : DomainBase
        {
            if (condition == null && selector == null)
                return await _context.Set<TEntity2>().ToListAsync();

            if (condition == null)
                return await _context.Set<TEntity2>().Select(selector).ToListAsync();

            if (selector == null)
                return await _context.Set<TEntity2>().Where(condition).ToListAsync();

            return await _context.Set<TEntity2>().Where(condition).Select(selector).ToListAsync();
        }
    }
}