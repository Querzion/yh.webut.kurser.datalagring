using System.Linq.Expressions;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm registrationForm)
    {
        if (await _customerRepository.ExistsAsync(x => x.CustomerName == registrationForm.CustomerName))
            return false;

        await _customerRepository.BeginTransactionAsync();

        try
        {
            await _customerRepository.AddAsync(new CustomerEntity { CustomerName = registrationForm.CustomerName });
            await _customerRepository.SaveAsync();
            
            await _customerRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _customerRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var entities = await _customerRepository.GetAsync();
        return entities.Select(CustomerFactory.Create);
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var entity = await _customerRepository.GetAsync(x => x.Id == id);
        return CustomerFactory.Create(entity!);
    }

    public async Task<Customer?> GetCustomerAsync(string customerName)
    {
        var entity = await _customerRepository.GetAsync(x => x.CustomerName == customerName);
        return CustomerFactory.Create(entity!);
    }

    public async Task<bool> CustomerExistsAsync(string customerName)
    {
        var result = await _customerRepository.ExistsAsync(x => x.CustomerName == customerName);
        return result;
    }


    public Task<bool> UpdateCustomerAsync(CustomerUpdateForm registrationForm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCustomerAsync(int id)
    {
        throw new NotImplementedException();
    }
}