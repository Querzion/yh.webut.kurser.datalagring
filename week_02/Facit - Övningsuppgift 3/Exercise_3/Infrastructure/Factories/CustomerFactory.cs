using Infrastructure.Models;

namespace Infrastructure.Factories;

public static class CustomerFactory
{
    public static CustomerRegistrationForm CreateRegistrationForm() => new();
    public static CustomerUpdateForm CreateUpdateForm() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
    };

    public static CustomerEntity Create(int id, CustomerUpdateForm form) => new()
    {
        Id = id,
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
    };

    public static Customer Create(CustomerEntity entity) => 
        new(entity.Id, entity.FirstName, entity.LastName, entity.Email, entity.PhoneNumber);
}
