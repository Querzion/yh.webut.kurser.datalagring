using Business.Services;
using Data.Entities;

namespace Presentation_Console.Dialogs;

public class MenuDialogs(IUserService userService) : IMenuDialogs
{
    private readonly IUserService _userService = userService;

    public void NewUserDialog()
    {
        var userEntity = new UserEntity();
        
        Console.Clear();
        Console.WriteLine("### CREATING NEW USER ###");
        Console.Write("First name: ");
        userEntity.FirstName = Console.ReadLine()!;
        Console.Write("Last name: ");
        userEntity.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        userEntity.Email = Console.ReadLine()!;
        Console.Write("Password: ");
        userEntity.Password = Console.ReadLine()!;
        Console.WriteLine();

        var result = _userService.CreateUser(userEntity);
        if (result != null)
        {
            Console.WriteLine($"Following user was created with id '{result.Id}'.");
            Console.Write($"{result.FirstName} {result.LastName} <{result.Email}>");
        }
        else
        {
            Console.WriteLine("Something went wrong while creating a new user.");
        }

        Console.ReadKey();
    }

    public void ViewAllUsersDialog()
    {
        Console.Clear();
        Console.WriteLine("### VIEWING ALL USERS ###");

        var result = _userService.GetUsers();
        if (result.Any())
        {
            foreach (var user in result)
            {
                Console.WriteLine($"Id: {user.Id}, Info: {user.FirstName} {user.LastName} <{user.Email}>");
            }
        }
        else
        {
            Console.WriteLine("No users were found.");
        }
        Console.ReadKey();
    }
}