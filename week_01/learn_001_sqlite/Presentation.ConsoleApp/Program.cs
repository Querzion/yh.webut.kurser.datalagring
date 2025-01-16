using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

// var userRepository = new UserRepository();
IUserRepository userRepository = new UserRepository();

#region Create User - Dialog

Console.WriteLine("### Create User ###");

var userEntity = new UserEntity();

Console.Write("First Name: ");
userEntity.FirstName = Console.ReadLine()!;
Console.Write("Last Name: ");
userEntity.LastName = Console.ReadLine()!;
Console.Write("Email: ");
userEntity.Email = Console.ReadLine()!;
Console.Write("Phone Number: ");
userEntity.PhoneNumber = Console.ReadLine()!;

var result = userRepository.Create(userEntity);
if (result)
    Console.WriteLine("User created successfully!");
else
    Console.WriteLine("User was not created!");

Console.ReadKey();

#endregion

#region Get All Users - Dialog

Console.WriteLine("\n### Get All Users ###");

var users = userRepository.GetAll();

foreach (var user in users)
    Console.WriteLine($"#{user.Id}, Name: {user.FirstName} {user.LastName} | Phone Number: {user.PhoneNumber} | Email: {user.Email}");

Console.ReadKey();

#endregion