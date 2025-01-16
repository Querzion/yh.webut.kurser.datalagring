using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

IUserRepository userRepository = new UserRepository();

#region Create User - Dialog
Console.WriteLine("### CREATE USER ###");

var userEntity = new UserEntity();

Console.Write("First name: ");
userEntity.FirstName = Console.ReadLine()!;
Console.Write("Last name: ");
userEntity.LastName = Console.ReadLine()!;
Console.Write("Email: ");
userEntity.Email = Console.ReadLine()!;
Console.Write("Phone number: ");
userEntity.PhoneNumber = Console.ReadLine()!;

var result = userRepository.Create(userEntity);

if (result)
    Console.WriteLine("User was created successfully!");
else
    Console.WriteLine("User was not created!");

Console.ReadKey();
Console.Clear();
#endregion

#region Show All Users

Console.WriteLine("### SHOW ALL USERS ###");

var users = userRepository.GetAll();

foreach (var user in users)
    Console.WriteLine($"#{user.Id}, Name: {user.FirstName} {user.LastName} | Contacts: {user.PhoneNumber} <{user.Email}>");

Console.ReadKey();

#endregion