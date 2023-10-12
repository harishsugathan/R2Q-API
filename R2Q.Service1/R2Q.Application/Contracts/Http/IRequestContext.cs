using R2Q.Domain.Enums;

namespace R2Q.Application.Contracts.Http
{
    /// <summary>
    /// Interface for abstracting HttpContext in the pipeline
    /// </summary>
    public interface IRequestContext
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        string UserId { get; }

        /// <summary>
        /// Gets the type of the role.
        /// </summary>
        /// <value>
        /// The type of the role.
        /// </value>
        RoleType RoleType { get; }

        /// <summary>
        /// Gets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        string TokenId { get; }

        /// <summary>
        /// Method to get the access token from the request
        /// </summary>
        /// <returns></returns>
        string GetAccessToken();
    }
}
