using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using R2Q.Application.Contracts.Http;
using R2Q.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using IdentityModel;

namespace R2Q.Infrastructure.Implementations.Http
{
    /// <summary>
    /// Defines the implementation for abstracting HttpContext in the pipeline
    /// </summary>
    public class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; private set; }

        /// <summary>
        /// Gets the type of the role.
        /// </summary>
        /// <value>
        /// The type of the role.
        /// </value>
        public RoleType RoleType { get; private set; }

        /// <summary>
        /// Gets the token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        public string TokenId { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        public RequestContext(IHttpContextAccessor httpContextAccessor)

        {
            this.httpContextAccessor = httpContextAccessor;
            SetUserDetailsFromToken();
        }

        /// <summary>
        /// Method to get the access token from the request
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken()
        {
            var requestHeaders = httpContextAccessor?.HttpContext?.Request?.Headers;
            if (requestHeaders != null)
            {
                var headers = requestHeaders.ToDictionary(l => l.Key.ToLowerInvariant(), k => k.Value.ToString());
                var authorizationHeader = HttpRequestHeader.Authorization.ToString().ToLowerInvariant();

                var token = headers.ContainsKey(authorizationHeader) ? headers[authorizationHeader] : string.Empty;
                if (!string.IsNullOrEmpty(token))
                {
                    return token.Replace($"{JwtBearerDefaults.AuthenticationScheme} ", string.Empty);
                }
            }

            return null;
        }

        /// <summary>
        /// Sets the user details from token.
        /// </summary>
        private void SetUserDetailsFromToken()
        {
            string bearerToken = GetAccessToken();

            if (!string.IsNullOrEmpty(bearerToken))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                if (tokenHandler.ReadToken(bearerToken) is JwtSecurityToken tokenSecure)
                {
                    var subjectClaimValue = tokenSecure.Claims?.First(claim => claim.Type == JwtClaimTypes.Subject)?.Value;
                    UserId = Convert.ToString(subjectClaimValue);

                    var roleClaimValue = tokenSecure.Claims?.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Role)?.Value;
                    var roleName = Convert.ToString(roleClaimValue);
                    if (!string.IsNullOrEmpty(roleName) && Enum.TryParse(roleName, out RoleType roleType))
                    {
                        RoleType = roleType;
                    }

                    var tokenIdClaimValue = tokenSecure.Claims?.FirstOrDefault(claim => claim.Type == JwtClaimTypes.JwtId)?.Value;
                    if (!string.IsNullOrEmpty(tokenIdClaimValue))
                    {
                        TokenId = tokenIdClaimValue;
                    }
                }
            }
        }
    }
}
