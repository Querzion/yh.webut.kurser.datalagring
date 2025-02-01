using System.Diagnostics;
using Business.Dtos;
using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<IResult> CreateUserAsync(UserRegistrationForm registrationForm)
    {
        if (registrationForm == null)
            return Result.BadRequest("Invalid registration form.");

        try
        {
            if (await _userRepository.ExistsAsync(x => x.Email == registrationForm.Email))
                return Result.BadRequest("User with the same email already exists.");

            var userEntity = UserFactory.Create(registrationForm);
           (userEntity.Password, userEntity.SecurityKey) = PasswordGenerator.Generate(registrationForm.Password);
           
           var result = await _userRepository.CreateAsync(userEntity);
           return result ? Result.Ok() : Result.Error("Unable to create user.");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetUsersAsync()
    {
        var userEntities = await _userRepository.GetAllAsync();
        var users = userEntities?.Select(UserFactory.Create);
        return Result<IEnumerable<User>>.Ok(users);
    }

    public async Task<IResult> GetUserByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        if (userEntity == null)
            return Result.BadRequest("User was not found.");
        
        var user = UserFactory.Create(userEntity);
        return Result<User>.Ok(user);
    }

    public async Task<IResult> GetUserByEmailAsync(string email)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Email == email);
        if (userEntity == null)
            return Result.BadRequest("User was not found.");
        
        var user = UserFactory.Create(userEntity);
        return Result<User>.Ok(user);
    }

    public async Task<IResult> UpdateUserAsync(int id, UserUpdateForm updateForm)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        if (userEntity == null)
            return Result.BadRequest("User was not found.");
        
        userEntity = UserFactory.Update(userEntity, updateForm);
        var result = await _userRepository.UpdateAsync(userEntity);
        return result ? Result.Ok() : Result.Error("Unable to update user.");
    }

    public async Task<IResult> DeleteUserAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        if (userEntity == null)
            return Result.BadRequest("User was not found.");
        
        var result = await _userRepository.DeleteAsync(userEntity);
        return result ? Result.Ok() : Result.Error("Unable to delete user.");
    }
}