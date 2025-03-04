using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerRegistrationForm CreateForm() => new();

    public static CustomerEntity Create(CustomerRegistrationForm registrationForm) => new()
    {
        CustomerName = registrationForm.CustomerName
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName
    };
    
    public static CustomerUpdateForm Create(Customer customer) => new()
    {
        Id = customer.Id,
        CustomerName = customer.CustomerName
    };

    public static CustomerEntity Create(CustomerEntity customerEntity, CustomerUpdateForm updateForm) => new()
    {
        Id = customerEntity.Id,
        CustomerName = updateForm.CustomerName
    };
}