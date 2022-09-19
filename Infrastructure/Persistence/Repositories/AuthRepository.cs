using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities.Auth;
using Core.Interfaces.Repository;
using Infrastructure.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly JwtSettings _jwtSettings;

        public AuthRepository(JwtSettings jwtSettings) => _jwtSettings = jwtSettings;


        public string GenerateJwt(User user) => GenerateEncryptedToken(GetSigningCredentials(), GetClaims(user));

        private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
               signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }


        private SigningCredentials GetSigningCredentials()
        {
            if (string.IsNullOrEmpty(_jwtSettings.Key))
            {
                throw new InvalidOperationException("No Key defined in JwtSettings config.");
            }

            byte[] secret = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }
        private IEnumerable<Claim> GetClaims(User user) =>
            new List<Claim>
            {
                    new(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new(ClaimTypes.Email, user.Email),
            };

    }




}

