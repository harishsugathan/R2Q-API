using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2Q.Application;
using R2Q.Application.Contracts.Encryption;
using R2Q.Application.Exceptions;
using ApplicationException = R2Q.Application.Exceptions.ApplicationException;

namespace R2Q.Infrastructure.Implementations.Encryption
{
    /// <summary>
    /// Defines the implementation of the Encryption service using AES
    /// </summary>
    /// <seealso cref="IEncryptionService" />
    internal class AesEncryptionService : IEncryptionService
    {
        private readonly string encryptionKey;
        private readonly ILogger<AesEncryptionService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AesEncryptionService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AesEncryptionService(
            IConfiguration configuration,
            ILogger<AesEncryptionService> logger)
        {
            encryptionKey = configuration.GetValue<string>("EncryptionKey");
            this.logger = logger;
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string DecryptString(string cipherText)
        {
            byte[] fullCipher;

            try
            {
                fullCipher = Convert.FromBase64String(cipherText);
            }
            catch (FormatException exception)
            {
                logger.LogError("Failed to get the complete cipher. Invalid cipher text.", exception);
                throw new ApplicationException(ExceptionCode.BadRequest, MessageKeys.InvalidToken);
            }

            if (fullCipher == null || fullCipher.Length <= 0)
            {
                throw new ArgumentNullException(cipherText);
            }

            string plaintext = null;
            var keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;

                using MemoryStream msDecrypt = new MemoryStream(fullCipher);
                byte[] iv = new byte[16];
                msDecrypt.Read(iv, 0, 16);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                CryptoStream csDecrypt = null;
                try
                {
                    csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        csDecrypt = null;
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
                finally
                {
                    if (csDecrypt != null)
                    {
                        csDecrypt.Dispose();
                    }
                }
            }

            return plaintext;
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string EncryptString(string text)
        {
            if (text == null || text.Length <= 0)
            {
                throw new ArgumentNullException(text);
            }

            byte[] encrypted;

            var keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                var iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncrypt = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    // Write iv
                    msEncrypt.Write(iv, 0, iv.Length);

                    // Write all data to the stream.
                    swEncrypt.Write(text);
                }

                encrypted = msEncrypt.ToArray();
            }

            return Convert.ToBase64String(encrypted);
        }
    }
}
