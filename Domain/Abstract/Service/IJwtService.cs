using Domain.Entities;
using Domain.Model;

namespace Domain.Abstract.Service;

public interface IJwtService
{
    Tokens Authenticate(User users);
}