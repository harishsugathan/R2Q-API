using R2Q.Application.Contracts.Identity;
using R2Q.Application.Dtos.Identity;
using R2Q.Application.Dtos.User;
using R2Q.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Infrastructure.Implementations.Identity
{
    public class IdentityService : IIdentityService
    {
        public Task<string> AddUser(UserDto request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserRole(ApplicationUser user, string userRole)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenDto> GetEmailConfirmationToken(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenDto> GetPasswordResetToken(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetRoleTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserEmailUnique(string email)
        {
            throw new NotImplementedException();
        }

        public Task SeedDefaultUserAndRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPasswordWithToken(string token, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateUser(ApplicationUser user, bool invalidateTokens)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserRole(ApplicationUser user, string userRole, string requestRoleName)
        {
            throw new NotImplementedException();
        }
    }
}
