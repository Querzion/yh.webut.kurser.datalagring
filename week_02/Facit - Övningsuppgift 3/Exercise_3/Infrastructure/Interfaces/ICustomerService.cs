using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<bool> DeleteCustomerAsync(int id);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Customer?> UpdateCustomerAsync(CustomerUpdateForm form);
}