using System.ComponentModel.DataAnnotations;

namespace SimpleLaundryuk.Application.Models.Customer;

public class RegisterNewCustomerRequest
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string MobilePhone { get; set; } = string.Empty;
}