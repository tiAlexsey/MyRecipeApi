using Domain.Abstract.Repository;
using Domain.Entities;

namespace Services.Database.Repository;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _repository;

    public UserRepository(DatabaseContext repository)
    {
        _repository = repository;
    }

    public bool IsValidUserInformation(User user)
    {
        if (_repository.User.Any(x => x.Login == user.Login && x.Password == user.Password))
        {
            return true;
        }

        return false;
    }
}