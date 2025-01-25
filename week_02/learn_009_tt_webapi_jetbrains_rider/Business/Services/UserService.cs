using Business.Contexts;
using Business.Entities;
using Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task RegisterNewUserAsync(UserRegistrationForm form)
    {
        var userEntity = new UserEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Password = form.Password,
        };
        
        _context.Users.Add(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        // var userList = new List<User>();
        // var users = await _context.Users.ToListAsync();
        //
        // foreach (var user in users)
        // {
        //     userList.Add(new User
        //     {
        //         Id = user.Id,
        //         FirstName = user.FirstName,
        //         LastName = user.LastName,
        //         Email = user.Email,
        //     });
        // }
        //
        // return userList;
        
        var users = await _context.Users.ToListAsync();
        return users.Select(user => new User()
            {
                Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email,
            })
            .ToList();
    }
}