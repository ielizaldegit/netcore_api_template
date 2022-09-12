using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities.Auth;
using Core.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository {
        public AuthRepository(ApplicationDbContext context)
        {
        }
    }

    public class UserRepository : GenericRepository<User>, IUserRepository {
        private readonly JwtSettings _jwtSettings;

        public UserRepository(ApplicationDbContext context, JwtSettings jwtSettings) : base(context) {
            _jwtSettings = jwtSettings;
        }

        public async Task<User> GetByUsernameAsync(string username) {
            return await _context.Users
                    .Include(u => u.Role)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Gender)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.MaritalStatus)
                    .Include(u => u.PersonUsers).ThenInclude(x => x.Person.Address)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Module)
                    .Include(u => u.ModuleUsers).ThenInclude(x => x.Permission)
                    .FirstOrDefaultAsync(u => u.Name.ToLower() == username.ToLower());
        }


        public string GenerateJwt(User user) => GenerateEncryptedToken(GetSigningCredentials(), GetClaims(user));



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


        private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
               signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

    }


    public class RoleRepository : GenericRepository<Role>, IRoleRepository {
        public RoleRepository(ApplicationDbContext context) : base(context) { }
        public override async Task<Role> GetByIdAsync(int id) {
            return await _context.Roles
                  .Include(u => u.ModuleRoles).ThenInclude(u => u.Module)
                  .Include(u => u.ModuleRoles).ThenInclude(x => x.Permission)
                  .FirstOrDefaultAsync(u => u.RoleId == id);
        }
    }





}

