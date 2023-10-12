
using R2Q.Common.Application.Constants;
using R2Q.Domain.Enums;

namespace R2Q.Common.Extensions
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
                    return Constants.Active;

                default:
                    return Constants.Inactive;
            }
        }
    }
}
