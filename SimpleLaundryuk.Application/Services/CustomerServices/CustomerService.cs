using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleLaundryuk.Application.Models.Customer;
using SimpleLaundryuk.Entity.Entities;
using SimpleLaundryuk.Infrastructure.Repositories;

namespace SimpleLaundryuk.Application.Services.CustomerServices;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;
    private readonly IPersistence _persistence;
    private readonly IMapper _mapper;

    public CustomerService(IRepository<Customer> repository, IPersistence persistence, IMapper mapper)
    {
        _repository = repository;
        _persistence = persistence;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> Create(RegisterNewCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        var customerSave = await _repository.Save(customer);
        var customerResponse = _mapper.Map<CustomerResponse>(customerSave);
        await _persistence.SaveChangeAsync();
        return customerResponse;
    }

    public async Task<CustomerResponse> GetById(string id)
    {
        return _mapper.Map<CustomerResponse>(await FindByIdOrThrowNotFound(id));
    }

    public async Task<List<CustomerResponse>> GetAll()
    {
        return _mapper.Map<List<CustomerResponse>>(await _repository.FindAll());
    }

    public async Task Update(UpdateCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        _repository.Update(customer);
        await _persistence.SaveChangeAsync();
    }

    public async Task DeleteById(string id)
    {
        var customer = await FindByIdOrThrowNotFound(id);
        _repository.Delete(customer);
        await _persistence.SaveChangeAsync();
    }

    private async Task<Customer> FindByIdOrThrowNotFound(string id)
    {
        try
        {
            var customer = await _repository.FindById(Guid.Parse(id));
            if (customer == null) throw new SystemException("customer not found");
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}