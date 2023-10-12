namespace R2Q.Application.Dtos.User
{
    /// <summary>
    /// User Dto class
    /// </summary>
    public class UserDto
    {
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>Gets or sets the role identifier.</summary>
        /// <value>The role identifier.</value>
        public int RoleId { get; set; }
    }
}
