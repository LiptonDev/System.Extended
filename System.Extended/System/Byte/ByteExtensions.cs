using System.Security.Cryptography;
using System.Text;

namespace System
{
    /// <summary>
    /// Extensions for <see cref="byte"/>.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        /// Gets base64 string from byte array.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="offset">An offset in bytes.</param>
        /// <param name="length">The number of elements of inArray to convert.</param>
        /// <param name="options">System.Base64FormattingOptions.InsertLineBreaks to insert a line break every 76 characters, or System.Base64FormattingOptions.None to not insert line breaks.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static string ConvertToBase64(this byte[] bytes, int offset, int length, Base64FormattingOptions options = Base64FormattingOptions.None)
        {
            bytes.EnsureNotNull(nameof(bytes));

            return Convert.ToBase64String(bytes, offset, length, options);
        }

        /// <summary>
        /// Gets string from byte array.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="encoding">Encoding. Default: UTF8.</param>
        /// <returns></returns>
        public static string ToString(this byte[] bytes, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            return encoding.GetString(bytes);
        }

        /// <summary>
        /// Gets hash from byte array.
        /// </summary>
        /// <param name="bytes">Bytes.</param>
        /// <param name="hashAlgorithm">Hash algorithm.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] GetHash(this byte[] bytes, HashAlgorithm hashAlgorithm)
        {
            bytes.EnsureNotNull(nameof(bytes));
            hashAlgorithm.EnsureNotNull(nameof(hashAlgorithm));

            return hashAlgorithm.ComputeHash(bytes);
        }
    }
}
