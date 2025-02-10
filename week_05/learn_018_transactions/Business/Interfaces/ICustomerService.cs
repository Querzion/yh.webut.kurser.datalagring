using System.Linq.Expressions;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface ICustomerService
{
    Task<bool> CreateCustomerAsync(CustomerRegistrationForm registrationForm);
    Task<IEnumerable<Customer?>> GetCustomersAsync();
    Task<Customer?> GetCustomerAsync(int id);
    Task<Customer?> GetCustomerAsync(string customerName);
    Task<bool> CustomerExistsAsync(string customerName);
    Task<bool> UpdateCustomerAsync(CustomerUpdateForm registrationForm);
    Task<bool> DeleteCustomerAsync(int id);
}