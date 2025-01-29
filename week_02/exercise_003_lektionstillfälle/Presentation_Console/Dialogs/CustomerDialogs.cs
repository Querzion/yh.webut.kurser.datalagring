using Infrastructure.Factories;
using Infrastructure.Interfaces;

namespace Presentation_Console.Dialogs;

public class CustomerDialogs(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public async Task CreateCustomerOption()
    {
        Console.Clear();
        Console.WriteLine("Create Customer");

        var customer = CustomerFactory.CreateRegistrationForm();
        Console.Write("First name: ");
        customer.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        customer.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        customer.Email = Console.ReadLine()!;
        Console.Write("Phone number: ");
        customer.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine();
        
        var result = await _customerService.CreateCustomerAsync(customer);
        if (result)
            Console.WriteLine("Customer successfully created!");
        else 
            Console.WriteLine("Customer could not be created!");

        Console.ReadKey();

    }
    
    public async Task ViewAllCustomersOption()
    {
         var customers = await _customerService.GetCustomerAsync();

         if (customers.Any())
         {
             foreach(var customer in customers)
                 Console.WriteLine($"{customer.Id}, {customer.FirstName} {customer.LastName} | {customer.Email}| {customer.PhoneNumber}");
         }
         else
             Console.WriteLine("No customers found!");
         
         Console.ReadKey();
    }
    
    public async Task ViewCustomerOption()
    {
        Console.Write("Customer Email: ");
        var email = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(email))
        {
            var customer = await _customerService.GetCustomerAsync(email);
            if (customer != null)
                Console.WriteLine($"{customer.Id}, {customer.FirstName} {customer.LastName} | {customer.Email}| {customer.PhoneNumber}");
            else
                Console.WriteLine("Customer not found!");
        }
        
        Console.ReadKey();
    }
    
    public async Task UpdateCustomerOption()
    {
        Console.Write("Customer Email: ");
        var selectedEmail = Console.ReadLine();
        
        if(!string.IsNullOrEmpty(selectedEmail))
        {
            var customer = await _customerService.GetCustomerAsync(selectedEmail);
            if (customer == null)
                Console.WriteLine("Customer not found!");
            else
            {
                Console.WriteLine($"Id: {customer.Id}");
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"PhoneNumber: {customer.PhoneNumber}");
                Console.WriteLine("");

                var customerUpdateForm = CustomerFactory.CreateUpdateForm();
                customerUpdateForm.Id = customer.Id;

                Console.Write("First name: ");
                var firstName = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(firstName) && firstName != customer.FirstName)
                    customerUpdateForm.FirstName = firstName;

                Console.Write("Last name: ");
                var lastName = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(lastName) && lastName != customer.FirstName)
                    customerUpdateForm.LastName = lastName;

                Console.Write("Email: ");
                var email = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(email) && email != customer.FirstName)
                    customerUpdateForm.Email = email;

                Console.Write("Phone number: ");
                var phone = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(phone) && phone != customer.FirstName)
                    customerUpdateForm.PhoneNumber = phone;

                customer = await _customerService.UpdateCustomerAsync(customerUpdateForm);

                if (customer != null)
                    Console.WriteLine($" id : {customer.Id} updated");
                else
                    Console.WriteLine("something went wrong");
            }

            Console.ReadKey();
        }
    }
    
    public async Task DeleteCustomerOption()
    {
        Console.Write("Customer Email: ");
        var selectedEmail = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(selectedEmail))
        {
            var customer = await _customerService.GetCustomerAsync(selectedEmail);
            if (customer == null)
                Console.WriteLine("Customer not found!");
            else
            {
                var result = await _customerService.DeleteCustomerAsync(customer.Id);
                if (result)
                    Console.WriteLine("Customer successfully deleted!");
                else
                    Console.WriteLine("Customer could not be deleted!");
            }
        }

        Console.ReadKey();
    }
    
    
    public async Task MenuOptions()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create new customer");
            Console.WriteLine("2. View All customers");
            Console.WriteLine("3. View customer");
            Console.WriteLine("4. Update customer");
            Console.WriteLine("5. Delete customer");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();

            switch (input)
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