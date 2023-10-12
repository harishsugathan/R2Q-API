using R2Q.Domain.Enums;
using R2Q.Application.Constants;

namespace R2Q.Application.Extensions
{
    /// <summary>
    /// Defines the extension methods for user status
    /// </summary>
    public static class UserStatusExtensions
    {
        /// <summary>
        /// Gets the name of the status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public static string GetStatusName(this UserStatus status)
        {
            switch (status)
            {
                case UserStatus.Active:
                    return R2QConstants.Active;

                default:
                    return R2QConstants.Inactive;
            }
        }
    }
}
