using Data.Entities;

namespace Business.Interfaces;

public interface IUserService
{
    Task<IAsyncResult> CreateUserAsync();
    Task<IAsyncResult> GetAllUsersAsync();
    Task<IAsyncResult> GetUserByIdAsync(int id);
    Task<IAsyncResult> UpdateUserAsync(int id);
    Task<IAsyncResult> DeleteUserAsync();
    
}