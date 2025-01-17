using Data.Enteties;

namespace Data.Interfaces;

public interface IUserRepository
{
    bool Create(UserEntity userEntity);
    IEnumerable<UserEntity> GetAll();
}