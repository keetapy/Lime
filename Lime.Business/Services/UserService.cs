using Lime.Business.DTO;
using Lime.Business.Infrastructure;
using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Business.Services
{
    class UserService : IUserService
    {
        IUnitOfWork db { get; set; }
        public UserService(IUnitOfWork unitOfWork )
        {
            db = unitOfWork;
        }
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await db.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await db.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await db.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email=userDto.Email, UserName=userDto.Email };
                var result = await db.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await db.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                db.IUserManager.Create(user);
                await db.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }
        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await db.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new Role { Name = roleName };
                    await db.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
