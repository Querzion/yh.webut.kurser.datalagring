using Data.Contexts;
using Data.Entities;

namespace Business.Services;

public class UserService(DataContext context) : IUserService
{
    private readonly DataContext _context = context;

    public UserEntity CreateUser(UserEntity userEntity)
    {
        try
        {
            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return userEntity;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }

    public IEnumerable<UserEntity> GetUsers()
    {
        return _context.Users;
    }

    public UserEntity GetUserById(int id)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == id);
        return userEntity ?? null!;
    }
    
    public UserEntity GetUserByEmail(string email)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Email == email);
        return userEntity ?? null!;
    }

    public UserEntity UpdateUser(UserEntity userEntity)
    {
        _context.Users.Update(userEntity);
        _context.SaveChanges();
        
        return userEntity;
    }

    public bool DeleteUserById(int id)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Id == id);
        if (userEntity != null)
        {
            _context.Users.Remove(userEntity);
            _context.SaveChanges();
        
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool DeleteUserByEmail(string email)
    {
        var userEntity = _context.Users.FirstOrDefault(u => u.Email == email);
        if (userEntity != null)
        {
            _context.Users.Remove(userEntity);
            _context.SaveChanges();
        
            return true;
        }
        else
        {
            return false;
        }
    }
}