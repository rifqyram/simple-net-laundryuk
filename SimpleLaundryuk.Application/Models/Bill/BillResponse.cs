using SimpleLaundryuk.Application.Models.BillDetail;

namespace SimpleLaundryuk.Application.Models.Bill;

public class BillResponse
{
    public string Id { get; set; } = string.Empty;
    public DateTime TransDate { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public List<BillDetailResponse> BillDetails { get; set; }
    public int GrandTotal { get; set; }
}