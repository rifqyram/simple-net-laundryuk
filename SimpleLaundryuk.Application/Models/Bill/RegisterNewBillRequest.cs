using System.ComponentModel.DataAnnotations;
using SimpleLaundryuk.Application.Models.BillDetail;

namespace SimpleLaundryuk.Application.Models.Bill;

public class RegisterNewBillRequest
{
    [Required] public string CustomerId { get; set; } = string.Empty;
    [Required] public List<RegisterNewBillDetailRequest> BillDetails { get; set; }
}