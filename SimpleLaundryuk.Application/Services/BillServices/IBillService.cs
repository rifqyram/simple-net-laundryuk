using SimpleLaundryuk.Application.Models.Bill;

namespace SimpleLaundryuk.Application.Services.BillServices;

public interface IBillService
{
    Task<BillResponse> CreateTransaction(RegisterNewBillRequest request);
    Task<BillResponse> GetTransactionById(string id);
    Task<List<BillResponse>> GetReport();
}