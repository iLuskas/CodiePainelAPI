using Codie.Painel.Domain.Authentication;
using Codie.Painel.Domain.Constants;
using Codie.Painel.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Codie.Painel.Application.Services
{
    public class AuthenticationService : ITokenGenerator
    {
        public string Generator(User user)
        {
            DateTime expirationTime = DateTime.UtcNow.AddDays(1);

            JwtSecurityTokenHandler tokenHandler = new();

            byte[] key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);

            var userClaims = new List<Claim>()
                {
                    //define o cookie
                    new Claim(ClaimTypes.Name, user!.Login),
                    new Claim(ClaimTypes.Email,user!.Email ),

                };

            if (user.RoleGate != null)
            {
                List<string> Roles = user.RoleGate.Split(",").ToList();

                foreach (var item in Roles)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, item));
                }
            }

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
