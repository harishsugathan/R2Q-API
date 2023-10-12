namespace R2Q.Application.Contracts.Encryption
{
    /// <summary>
    /// Defines the contract for the encryption service
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        string EncryptString(string text);

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        string DecryptString(string cipherText);
    }
}
