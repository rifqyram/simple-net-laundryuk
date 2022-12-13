using AutoMapper;
using SimpleLaundryuk.Application.Models.Customer;
using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Entity.Entities;

namespace SimpleLaundryuk.Application.Mapping;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<Customer, CustomerResponse>();
    }
}