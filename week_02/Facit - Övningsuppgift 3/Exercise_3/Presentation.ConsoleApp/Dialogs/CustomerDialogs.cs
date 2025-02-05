using Infrastructure.Factories;
using Infrastructure.Interfaces;
using Presentation.ConsoleApp.Interfaces;

namespace Presentation.ConsoleApp.Dialogs;

public class CustomerDialogs(ICustomerService customerService) : ICustomerDialogs
{
    private readonly ICustomerService _customerService = customerService;

    public async Task CreateCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("#### CREATE CUSTOMER ####");

        var customer = CustomerFactory.CreateRegistrationForm();
        Console.Write("First Name: ");
        customer.FirstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        customer.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        customer.Email = Console.ReadLine()!;
        Console.Write("Phone Number: ");
        customer.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine();

        var result = await _customerService.CreateCustomerAsync(customer);
        if (result)
            Console.WriteLine("\nCustomer was created successfully.");
        else
            Console.WriteLine("\nCustomer was not created.");

        Console.ReadKey();
    }

    public async Task ViewAllCustomersOption()
    {
        Console.Clear();
        Console.WriteLine("#### VIEW ALL CUSTOMERs ####");

        var customers = await _customerService.GetCustomersAsync();

        if (customers.Any())
        {
            foreach (var customer in customers)
                Console.WriteLine($"{customer.Id}, {customer.FirstName} {customer.LastName} <{customer.Email}>");
        }
        else
            Console.WriteLine("No customers was found.");

        Console.ReadKey();
    }

    public async Task ViewCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("#### VIEW CUSTOMER ####");

        Console.Write("Customer Email: ");
        var email = Console.ReadLine()!;

        var customer = await _customerService.GetCustomerByEmailAsync(email);
        if (customer != null)
            Console.WriteLine($"{customer.Id}, {customer.FirstName} {customer.LastName} <{customer.Email}>");
        else
            Console.WriteLine("Customer was not found.");

        Console.ReadKey();
    }

    public async Task UpdateCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("#### UPDATE CUSTOMER ####");

        Console.Write("Customer Email: ");
        var selectedEmail = Console.ReadLine()!;

        var customer = await _customerService.GetCustomerByEmailAsync(selectedEmail);
        if (customer == null)
            Console.WriteLine("Customer was not found.");
        else
        {
            Console.WriteLine($"Id: {customer.Id}");
            Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
            Console.WriteLine("");

            var customerUpdateForm = CustomerFactory.CreateUpdateForm();
            customerUpdateForm.Id = customer.Id;

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(firstName) && firstName != customer.FirstName)
                customerUpdateForm.FirstName = firstName;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(lastName) && lastName != customer.FirstName)
                customerUpdateForm.LastName = lastName;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(email) && email != customer.FirstName)
                customerUpdateForm.Email = email;

            Console.Write("Phone Number: ");
            var phoneNumber = Console.ReadLine()!;
            if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber != customer.FirstName)
                customerUpdateForm.PhoneNumber = phoneNumber;

            customer = await _customerService.UpdateCustomerAsync(customerUpdateForm);
            if (customer != null)
                Console.WriteLine($"{customer.Id}, {customer.FirstName} {customer.LastName} <{customer.Email}>");
            else
                Console.WriteLine("Something went wrong!");
        }

        Console.ReadKey();
    }

    public async Task DeleteCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("#### DELETE CUSTOMER ####");

        Console.Write("Customer Email: ");
        var selectedEmail = Console.ReadLine()!;

        var customer = await _customerService.GetCustomerByEmailAsync(selectedEmail);
        if (customer == null)
            Console.WriteLine("Customer was not found.");
        else
        {
            var result = await _customerService.DeleteCustomerAsync(customer.Id);
            if (result)
                Console.WriteLine($"Customer was deleted successfully.");
            else
                Console.WriteLine("Something went wrong!");
        }

        Console.ReadKey();
    }

    public async Task MenuOptions()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("#### MENU OPTIONS ####");
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. View Customer");
            Console.WriteLine("4. Update Customer");
            Console.WriteLine("5. Delete Customer");
            Console.Write("SELECTED MENU OPTION: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateCustomerOption();
                    break;

                case "2":
                    await ViewAllCustomersOption();
                    break;

                case "3":
                    await ViewCustomerOption();
                    break;
                case "4":
                    await UpdateCustomerOption();
                    break;

                case "5":
                    await DeleteCustomerOption();
                    break;
            }
        }
    }
}
