using AssoSw.Lesson7.AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Services
{
    public class TokenService
    {
        private readonly JwtTokenOptions _options;

        public TokenService(IOptions<JwtTokenOptions> options)
        {
            _options = options.Value;
        }

        private const int ExpirationMinutes = 30;

        public JwtSecurityToken CreateToken(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
            SigningCredentials signingCredentials = CreateSigningCredentials();
            List<Claim> claims = CreateClaims(user);
            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
            );

            return token;
        }

        private List<Claim> CreateClaims(IdentityUser user)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
                return claims;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SigningKey)
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
