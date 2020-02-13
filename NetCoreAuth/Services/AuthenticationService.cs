using Microsoft.IdentityModel.Tokens;
using NetCoreAuth.Infrastructures.Repositories;
using NetCoreAuth.Infrastructures.Services;
using NetCoreAuth.Models.DataModels;
using NetCoreAuth.Models.ViewModels;
using NetCoreAuth.Repositories;
using NetCoreAuth.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace NetCoreAuth.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly Func<IUserRepository> _userRepositoryFactory;
        public AuthenticationService()
        {
            _userRepositoryFactory = () => new UserRepository();
        }

        public string Authenticate(AuthenticationModel input)
        {
            //1. Check login
            User user;
            using (var userRepo = _userRepositoryFactory.Invoke())
            {
                user = userRepo.Login(input.Username, input.Password);
            }
            //2. Init claims
            var claims = new List<Claim>
            {
                new Claim(AppClaimType.Id, user.Id.ToString()),
                new Claim(AppClaimType.Username, user.Username),
                new Claim(AppClaimType.FirstName, user.FirstName),
                new Claim(AppClaimType.RoleId, user.RoleId.ToString()),
            };

            //3. Config token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(TokenSettings.ExpireHour),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenSettings.SecurityKey), SecurityAlgorithms.HmacSha256Signature)
            };

            //4. Generate and return jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
            ;
        }
    }
}
