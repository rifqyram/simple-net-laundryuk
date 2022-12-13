using SimpleLaundryuk.Application.Models.Product;

namespace SimpleLaundryuk.Application.Models.BillDetail;

public class RegisterNewBillDetailRequest
{
    public int Weight { get; set; }
    public string ProductPriceId { get; set; } = string.Empty;
}