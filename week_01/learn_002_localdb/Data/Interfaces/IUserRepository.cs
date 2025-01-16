using Data.Entities;

namespace Data.Interfaces;

public interface IUserRepository
{
    bool Create(UserEntity userEntity);
    IEnumerable<UserEntity> GetAll();
}