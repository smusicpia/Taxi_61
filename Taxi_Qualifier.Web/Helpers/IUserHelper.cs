﻿using Microsoft.AspNetCore.Identity;

using System;
using System.Threading.Tasks;
using Taxi_Qualifier.Web.Data.Entities;
using Taxi_Qualifier.Web.Models;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserAsync(string email);

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<UserEntity> AddUserAsync(AddUserViewModel model, string path);

        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserEntity user);

        Task<SignInResult> ValidatePasswordAsync(UserEntity user, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);

        Task<IdentityResult> ConfirmEmailAsync(UserEntity user, string token);

    }
}
