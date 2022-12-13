using System.ComponentModel.DataAnnotations;

namespace SimpleLaundryuk.Application.Models.Customer;

public class UpdateCustomerRequest
{
    [Required] public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MobilePhone { get; set; } = string.Empty;
}