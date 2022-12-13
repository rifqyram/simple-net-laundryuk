using SimpleLaundryuk.Application.Models.Customer;

namespace SimpleLaundryuk.Application.Services.CustomerServices;

public interface ICustomerService
{
    Task<CustomerResponse> Create(RegisterNewCustomerRequest request);
    Task<CustomerResponse> GetById(string id);
    Task<List<CustomerResponse>> GetAll();
    Task Update(UpdateCustomerRequest request);
    Task DeleteById(string id);
}