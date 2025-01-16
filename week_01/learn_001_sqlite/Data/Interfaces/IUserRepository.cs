using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository
{
    // bool Create(string firstName, string lastName, string email, string phoneNumber);
    bool Create(UserEntity userEntity);
    
    IEnumerable<UserEntity> GetAll();
}