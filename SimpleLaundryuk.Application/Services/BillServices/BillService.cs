using SimpleLaundryuk.Application.Models.Bill;
using SimpleLaundryuk.Application.Models.BillDetail;
using SimpleLaundryuk.Application.Models.Product;
using SimpleLaundryuk.Application.Models.ProductPrice;
using SimpleLaundryuk.Application.Services.CustomerServices;
using SimpleLaundryuk.Application.Services.ProductPriceServices;
using SimpleLaundryuk.Entity.Entities;
using SimpleLaundryuk.Infrastructure.Repositories;

namespace SimpleLaundryuk.Application.Services.BillServices;

public class BillService : IBillService
{
    private readonly IRepository<Bill> _repository;
    private readonly IPersistence _persistence;
    private readonly ICustomerService _customerService;
    private readonly IProductPriceService _productPriceService;

    public BillService(IRepository<Bill> repository, IPersistence persistence, ICustomerService customerService,
        IProductPriceService productPriceService)
    {
        _repository = repository;
        _persistence = persistence;
        _customerService = customerService;
        _productPriceService = productPriceService;
    }

    public async Task<BillResponse> CreateTransaction(RegisterNewBillRequest request)
    {
        return await _persistence.ExecuteTransactionAsync(async () =>
        {
            var customerResponse = await _customerService.GetById(request.CustomerId);

            _persistence.ClearTracking();

            var billDetails = new List<BillDetail>();
            var grandTotal = 0;

            foreach (var billDetailRequest in request.BillDetails)
            {
                var productPriceResponse = await _productPriceService.GetById(billDetailRequest.ProductPriceId);
                _persistence.ClearTracking();

                billDetails.Add(new BillDetail
                {
                    Weight = billDetailRequest.Weight,
                    ProductPrice = new ProductPrice
                    {
                        Id = Guid.Parse(productPriceResponse.Id)
                    }
                });

                grandTotal += productPriceResponse.Price * billDetailRequest.Weight;
            }

            var bill = new Bill
            {
                Customer = new Customer
                {
                    Id = Guid.Parse(customerResponse.Id)
                },
                BillDetails = billDetails
            };

            _repository.Attach(bill);
            await _persistence.SaveChangeAsync();

            var billDetailResponses = bill.BillDetails.Select(billDetail => new BillDetailResponse
            {
                Id = billDetail.Id.ToString(),
                Weight = billDetail.Weight,
                ProductPrice = new ProductPriceResponse
                {
                    Id = billDetail.ProductPrice.Id.ToString(),
                    Price = billDetail.ProductPrice.Price,
                    IsActive = billDetail.ProductPrice.IsActive,
                    Product = new ProductResponse
                    {
                        Id = billDetail.ProductPrice.Product.Id.ToString(),
                        Name = billDetail.ProductPrice.Product.Name,
                        Duration = billDetail.ProductPrice.Product.Duration,
                    }
                },
            }).ToList();

            return new BillResponse
            {
                Id = bill.Id.ToString(),
                TransDate = bill.TransDate,
                CustomerId = customerResponse.Id,
                BillDetails = billDetailResponses,
                GrandTotal = grandTotal
            };
        });
    }

    public async Task<BillResponse> GetTransactionById(string id)
    {
        var bill = await FindByIdOrThrowNotFound(id);
        
        var billDetailResponses = new List<BillDetailResponse>();
        var grandTotal = 0;
        
        foreach (var billDetail in bill.BillDetails!)
        {
            var billDetailResponse = new BillDetailResponse
            {
                Id = billDetail.Id.ToString(),
                Weight = billDetail.Weight,
                ProductPrice = new ProductPriceResponse
                {
                    Id = billDetail.ProductPrice.Id.ToString(),
                    Price = billDetail.ProductPrice.Price,
                    IsActive = billDetail.ProductPrice.IsActive,
                    Product = new ProductResponse
                    {
                        Id = billDetail.ProductPrice.Product.Id.ToString(),
                        Name = billDetail.ProductPrice.Product.Name,
                        Duration = billDetail.ProductPrice.Product.Duration,
                    }
                }
            };
            billDetailResponses.Add(billDetailResponse);
            grandTotal += billDetail.ProductPrice.Price * billDetail.Weight;
        }
        
        return new BillResponse
        {
            Id = bill.Id.ToString(),
            TransDate = bill.TransDate,
            CustomerId = bill.Customer.Id.ToString(),
            BillDetails = billDetailResponses,
            GrandTotal = grandTotal
        };
    }

    public Task<List<BillResponse>> GetReport()
    {
        throw new NotImplementedException();
    }

    private async Task<Bill> FindByIdOrThrowNotFound(string id)
    {
        try
        {
            var bill = await _repository.FindById(Guid.Parse(id), new []{ "BillDetails.ProductPrice.Product", "Customer" });
            if (bill is null) throw new Exception("bill not found");
            return bill;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}