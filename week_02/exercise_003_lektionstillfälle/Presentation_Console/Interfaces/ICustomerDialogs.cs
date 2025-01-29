namespace Presentation_Console.Interfaces;

public interface ICustomerDialogs
{
    Task CreateCustomerOption();
    Task ViewAllCustomersOption();
    Task ViewCustomerOption();
    Task UpdateCustomerOption();
    Task DeleteCustomerOption();
    Task MenuOptions();
}