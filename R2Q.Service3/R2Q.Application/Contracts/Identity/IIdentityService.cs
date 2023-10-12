using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using R2Q.Application.Dtos.Identity;
using R2Q.Application.Dtos.User;
using R2Q.Domain.Entities;

namespace R2Q.Application.Contracts.Identity
{
    /// <summary>
    /// Defines the contract for the identity service
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Seeds the default user and roles asynchronous.
        /// </summary>
        /// <returns></returns>
        Task SeedDefaultUserAndRolesAsync();

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <returns></returns>
        Task<string> AddUser(UserDto request);

        /// <summary>
        /// Checks whether email is unique.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<bool> IsUserEmailUnique(string email);

        /// <summary>
        /// Gets the role types.
        /// </summary>
        /// <returns></returns>
        Task<List<Role>> GetRoleTypes(CancellationToken cancellationToken);

        /// <summary>
        /// Gets the email confirmation token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<UserTokenDto> GetEmailConfirmationToken(string email);

        /// <summary>
        /// Gets the password reset token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        Task<UserTokenDto> GetPasswordResetToken(string email);

        /// <summary>
        /// Sets the password with token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<bool> SetPasswordWithToken(string token, string password);

       

        /// Updates the user role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userRole">The user role.</param>
        /// <param name="requestRoleName">Name of the request role.</param>
        /// <returns></returns>
        Task UpdateUserRole(ApplicationUser user, string userRole, string requestRoleName);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="invalidateTokens">if set to <c>true</c> [invalidate tokens].</param>
        /// <returns></returns>
        Task<string> UpdateUser(ApplicationUser user, bool invalidateTokens);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task DeleteUser(ApplicationUser user);

        /// <summary>
        /// Deletes the user role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userRole">Name of the role.</param>
        /// <returns></returns>
        Task DeleteUserRole(ApplicationUser user, string userRole);
    }
}
