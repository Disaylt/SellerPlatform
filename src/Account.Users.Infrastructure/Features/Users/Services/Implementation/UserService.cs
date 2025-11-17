using System.Net;
using Account.Users.Application.Features.Users.Services.Abstraction;
using Account.Users.Domain.Entities;
using Account.Users.Infrastructure.Features.Users.Models;
using Account.Users.Infrastructure.Features.Users.Utilities.Abstraction;
using Core.Abstraction.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Account.Users.Infrastructure.Features.Users.Services.Implementation
{
    public class UserService(UserManager<AppIdentityUser> userManager, IUserMapper userMapper) : IUserService
    {
        public async Task<User> FindByLoginAsync(string login)
        {
            var user = await userManager.FindByNameAsync(login)
                ?? throw new CoreRequestException()
                    .SetStatusCode(HttpStatusCode.NotFound)
                    .AddMessages("Пользователь с таким именем не найден.");

            return userMapper.ToEntity(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email)
                ?? throw new CoreRequestException()
                    .SetStatusCode(HttpStatusCode.NotFound)
                    .AddMessages("Пользователь с такой почтой не найден.");

            return userMapper.ToEntity(user);
        }

        public async Task<User> CreateAsync(string login, string email, string password)
        {
            var identityUser = new AppIdentityUser
            {
                Email = email,
                UserName = login
            };

            var result = await userManager.CreateAsync(identityUser, password);

            if(result.Succeeded is false)
            {
                throw CreateBadRegisterException();
            }

            return userMapper.ToEntity(identityUser);
        }

        public async Task DeleteAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id)
                ?? throw CreateUserNotFoundException();

            await userManager.DeleteAsync(user);
        }

        public async Task<bool> VerifyPassword(string userNameOrEmail, string password)
        {
            var user = await userManager.FindByEmailAsync(userNameOrEmail)
                ?? await userManager.FindByNameAsync(userNameOrEmail);

            if (user is null) return false;

            return await userManager.CheckPasswordAsync(user, password);
        }

        private static CoreRequestException CreateBadRegisterException()
        {
            return new CoreRequestException()
                    .AddKeyMessages("Не удалось зарегистрировать пользователя.");
        }

        private static CoreRequestException CreateUserNotFoundException()
        {
            return new CoreRequestException()
                    .SetStatusCode(HttpStatusCode.BadRequest)
                    .AddKeyMessages("Пользователь не найден.");
        }
    }
}
