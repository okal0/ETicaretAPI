
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ETicaretAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDTO CreateAccessToken(int min)
        {
            TokenDTO token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // şifrelenmiş kimlik
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(min);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token.Audience"],
                issuer: _configuration["Token.Issuer"],
                expires: token.Expiration,
                signingCredentials: credentials,
                notBefore: DateTime.UtcNow
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            return token;
        }

        public string CreateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
