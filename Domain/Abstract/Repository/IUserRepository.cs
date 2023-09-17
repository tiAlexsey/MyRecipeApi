using Domain.Entities;

namespace Domain.Abstract.Repository;

public interface IUserRepository
{
    public bool IsValidUserInformation(User user);
}