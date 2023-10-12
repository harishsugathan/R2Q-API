namespace R2Q.Application
{
    public static class MessageKeys
    {
        #region Common
        public const string InvalidRequest = "Messages.InvalidRequest";
        #endregion

        #region Vendor
        public const string FirstNameMandatory = "Messages.FirstNameMandatory";
        public const string FirstNameLimitExceeds = "Messages.FirstNameLimitExceeds";
        public const string TokenMandatory = "Messages.Token";
        #endregion Vendor

        #region Login

        public const string UsernameNotFound = "Messages.UsernameNotFound";
        public const string InvalidUsernamePassword = "Messages.InvalidUsernamePassword";
        public const string SessionExpired = "Messages.SessionExpired";
        public const string NotAuthorizedForAutoDeskPlugin = "Messages.NotAuthorizedForAutoDeskPlugin";

        #endregion

        #region Account

        public const string UserEmailNotFound = "Messages.UserEmailNotFound";
        public const string UserInactive = "Messages.UserInactive";
        public const string InvalidPassword = "Messages.InvalidPassword";
        public const string PasswordVerificationLinkExpired = "Messages.PasswordVerificationLinkExpired";
        public const string PasswordLengthInvalid = "Messages.PasswordLengthInvalid";
        public const string PasswordSpecialCharacterRequired = "Messages.PasswordSpecialCharacterRequired";
        public const string PasswordNumberRequired = "Messages.PasswordNumberRequired";
        public const string PasswordWhiteSpaceNotAllowed = "Messages.PasswordWhiteSpaceNotAllowed";
        public const string ConfirmPasswordIsRequired = "Messages.ConfirmPasswordIsRequired";
        public const string InvalidConfirmedPassword = "Messages.InvalidConfirmedPassword";
        public const string InvalidToken = "Messages.InvalidToken";

        #endregion


    }

}

