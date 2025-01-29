using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(CustomerRegistrationForm form);
    Task<IEnumerable<Customer>> GetCustomerAsync();
    Task<Customer?> GetCustomerAsync(int id);
    Task<Customer?> GetCustomerAsync(string email);
    Task<Customer?> UpdateCustomerAsync(CustomerUpdateForm form);
    Task<bool> DeleteCustomerAsync(int id);
}