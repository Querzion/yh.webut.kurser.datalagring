using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    // CREATE
    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var customer = await _customerRepository.GetAsync(x => x.Email == form.Email);
        if (customer != null)
            return false;

        customer = CustomerFactory.Create(form);

        var result = await _customerRepository.CreateAsync(customer);
        return result;
    }


    // READ
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(CustomerFactory.Create);
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetAsync(x => x.Id == id);
        return customer != null ? CustomerFactory.Create(customer) : null;
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        var customer = await _customerRepository.GetAsync(x => x.Email == email);
        return customer != null ? CustomerFactory.Create(customer) : null;
    }

    // UPDATE
    public async Task<Customer?> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        var customer = await _customerRepository.GetAsync(x => x.Id == form.Id);
        if (customer == null)
            return null;

        customer = CustomerFactory.Create(customer.Id, form);

        await _customerRepository.UpdateAsync(customer);

        customer = await _customerRepository.GetAsync(x => x.Id == form.Id);
        return customer != null ? CustomerFactory.Create(customer) : null;
    }


    // DELETE
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = await _customerRepository.GetAsync(x => x.Id == id);
        if (customer == null)
            return false;

        var result = await _customerRepository.DeleteAsync(customer);
        return result;
    }
}
