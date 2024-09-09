using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Taxi_Qualifier.Web.Data.Entities;
using Taxi_Qualifier.Web.Models;

namespace Taxi_Qualifier.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

    }
}
