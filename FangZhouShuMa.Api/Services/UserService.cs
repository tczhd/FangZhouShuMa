using FangZhouShuMa.Api.Helpers;
using FangZhouShuMa.Api.Interfaces;
using FangZhouShuMa.Api.Models.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FangZhouShuMa.Infrastructure.Identity;
using FangZhouShuMa.Framework.Enums;

namespace FangZhouShuMa.Api.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        //};

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolesManager;
        private readonly AppSettings _appSettings;

        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = roleManager;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string userName, string password)
        {
            // var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            var user = Login( userName,  password).Result;

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    // return users without passwords
        //    return _users.Select(x =>
        //    {
        //        x.Password = null;
        //        return x;
        //    });
        //}

        private async Task<User> Login(string userName, string password)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }
            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains(UserRoleType.Customer.ToString()))
            {
                return null;
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var appUser = new User { Id = user.Id, FirstName = user.UserName, LastName = "", Username = userName, Password = "" };
                return appUser;
            }

            return null ;
        }
    }
}
