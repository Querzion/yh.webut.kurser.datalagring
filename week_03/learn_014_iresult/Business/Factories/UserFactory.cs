using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static UserEntity Create(UserRegistrationForm registrationForm) => new()
    {
        FirstName = registrationForm.FirstName,
        LastName = registrationForm.LastName,
        Email = registrationForm.Email.ToLower(),
        RoleId = 2
    };

    public static User Create(UserEntity userEntity) => new()
    {
        Id = userEntity.Id,
        FirstName = userEntity.FirstName,
        LastName = userEntity.LastName,
        Email = userEntity.Email,
        RoleName = userEntity.Role.RoleName
    };

    public static UserEntity Update(UserEntity userEntity, UserUpdateForm updateForm) => new()
    {
        Id = userEntity.Id,
        FirstName = updateForm.FirstName,
        LastName = updateForm.LastName,
        Email = userEntity.Email,
        Password = userEntity.Password,
        SecurityKey = userEntity.SecurityKey,
        
        
    };


}