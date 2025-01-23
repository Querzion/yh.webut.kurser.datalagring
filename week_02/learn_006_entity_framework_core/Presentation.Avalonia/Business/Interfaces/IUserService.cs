using Data.Entities;

namespace Business.Services;

public interface IUserService
{
    UserEntity CreateUser(UserEntity userEntity);
    IEnumerable<UserEntity> GetUsers();
    UserEntity GetUserById(int id);
    UserEntity GetUserByEmail(string email);
    UserEntity UpdateUser(UserEntity userEntity);
    bool DeleteUserById(int id);
    bool DeleteUserByEmail(string email);
}