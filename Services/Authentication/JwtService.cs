using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Abstract.Repository;
using Domain.Abstract.Service;
using Domain.Entities;
using Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Authentication.Config;

namespace Services.Authentication;

public class JwtService : IJwtService
{
    private readonly JwtConfig _config;
    private readonly IUserRepository _repository;

    public JwtService(IOptions<JwtConfig> config, IUserRepository repository)
    {
        _config = config.Value;
        _repository = repository;
    }

    public Tokens Authenticate(User user)
    {
        if (!_repository.IsValidUserInformation(user))
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_config.Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config.Issuer,
            Audience = _config.Audience,
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Login)
            }),
            Expires = DateTime.UtcNow.AddHours(12),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
}