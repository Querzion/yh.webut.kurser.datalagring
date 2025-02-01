using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces;

public interface IUserService
{
    Task<IResult> CreateUserAsync(UserRegistrationForm registrationForm);
    Task<IResult> GetUsersAsync();
    Task<IResult> GetUserByIdAsync(int id);
    Task<IResult> GetUserByEmailAsync(string email);
    Task<IResult> UpdateUserAsync(int id, UserUpdateForm updateForm);
    Task<IResult> DeleteUserAsync(int id);
    
}