using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.ViewModels.ViewItems;
using Lime.ViewModels.ViewModels;
using Lime.ViewModels.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthorizationService(UserManager<User> userManage, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManage;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        
        public async Task<string> SingUp(SignUpAuthorizationViewModel viewModel)
        {
            var user = new User
            {
                UserName = viewModel.Email,
                SecurityStamp=Guid.NewGuid().ToString(),
                Email = viewModel.Email
                
            };
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.FirstOrDefault()?.Description);
            }
            var appUser = _userManager.Users.SingleOrDefault(r => r.Email == viewModel.Email);

            var code = GenerateJwtToken(appUser);
            return $"Succeeded SingUp\nYour token: {code}";
        }

        public async Task<SignInAccountView> SignIn(SignInAuthorizationViewModel model)
        {
            User identityUser = _userManager.Users.SingleOrDefault(x => x.NormalizedUserName == model.Email.ToUpper());
            if (identityUser == null)
            {
                throw new ApplicationException("User not found.");
            }
            var userResult = new UserAccountViewItem
            {
                UserEmail = identityUser.Email,
                UserId = identityUser.Id,
                UserName = identityUser.UserName
            };
            var resultView = new SignInAccountView { Token = GenerateJwtToken(identityUser), User = userResult };

            return resultView;
        }
        private string GenerateJwtToken(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
