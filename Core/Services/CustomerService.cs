using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using DomainModel;
using DomainModel.Models;
using Models.Filter;
using Models.Models;

namespace Core.Services
{
    public interface ICustomerService : IService<CustomerModel>
    {
        Task<CustomerModel> GetSingleWithIdAsync(int id);
        Task<IList<CustomerModel>> SearchWithFilterToGetListAsync(CustomerFilter filter);
    }
    public class CustomerService : Service<CustomerModel , Customer> , ICustomerService
    {

        public override async Task<IList<CustomerModel>> GetAllAsync()
        {
            try{
                var entities = await Repository.FindByAsync(null, (a=> new Customer{
                    Address = a.Address,
                    CustomerName = a.CustomerName,
                    CustomerId = a.CustomerId,
                    Vehicles = a.Vehicles
                }));
                return ConvertFromEntityToModel(entities);
            }catch(Exception e){
                Console.WriteLine(e);
                throw;
            }
        }

       
        public async Task<CustomerModel> GetSingleWithIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    return (await ListToFiltered(c => c.CustomerId == id)).FirstOrDefault();
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<CustomerModel>> SearchWithFilterToGetListAsync(CustomerFilter filter)
        {
            try
            {
                if (filter.HasVehicleStatus)
                {
                    return await ListToFiltered(c => c.Vehicles.Any(v => v.ShowStatus)); 
                }

                if (!string.IsNullOrEmpty(filter.CustomerName))
                {
                    return await ListToFiltered(c => c.CustomerName.Contains(filter.CustomerName));
                }
                return await ListToFiltered(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<IList<CustomerModel>> ListToFiltered(Expression<Func<Customer, bool>> condition)
        {
            var entityList = await Repository.FindByAsync(condition, c => new Customer
            {
                CustomerId = c.CustomerId,
                Address = c.Address,
                CustomerName = c.CustomerName,
                Vehicles = c.Vehicles.Select(v=>new Vehicle
                {
                    VehicleId = v.VehicleId,
                    RegisterNumber = v.RegisterNumber,
                    ShowStatus = v.ShowStatus
                }).ToList()
            });
            return ConvertFromEntityToModel(entityList);
        }

        public CustomerService(IRepository<Customer> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}