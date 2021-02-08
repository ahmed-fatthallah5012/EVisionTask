using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainModel;
using DomainModel.Models;
using Models.Models;

namespace Core.Services
{
    public interface IService<TModel>
    {
        Task<TModel> SaveAsync(TModel model);
        Task<TModel> RemoveAsync(TModel model);
        Task<IList<TModel>> GetAllAsync();
    }
    public abstract class Service<TModel , TEntity> : IService<TModel> 
        where TModel : ModelBase
        where TEntity : DomainBase
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        protected Service(IRepository<TEntity> repository , IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }


        public virtual async Task<TModel> SaveAsync(TModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var entity = Mapper.Map<TEntity>(model);
                await Repository.BeginTransactionAsync();
                Repository.InsertOrUpdate(entity);
                await Repository.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<TModel> RemoveAsync(TModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var entity = Mapper.Map<TEntity>(model);
                await Repository.BeginTransactionAsync();
                Repository.Remove(entity);
                await Repository.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<IList<TModel>> GetAllAsync()
        {
            try
            {
                return ConvertFromEntityToModel(await Repository.GetAllAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected IList<TModel> ConvertFromEntityToModel(IList<TEntity> entities) 
            => Mapper.Map<IList<TModel>>(entities);
    }
}