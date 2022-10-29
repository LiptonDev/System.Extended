using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace System
{
    /// <summary>
    /// Extensions for <see cref="String"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checking string for empty, spaces and null.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the specified input string.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="regexPattern">The regular expression pattern to match.</param>
        /// <param name="options">A bitwise combination of the enumeration values that provide options for matching.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="RegexMatchTimeoutException"/>
        /// <returns></returns>
        public static bool IsMatch(this string value, string regexPattern, RegexOptions options = RegexOptions.None)
        {
            return Regex.IsMatch(value, regexPattern, options);
        }

        /// <summary>
        /// Convert <see cref="string"/> value to bytes with encoding.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="encoding">Encoding. Default value: UTF8.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="EncoderFallbackException"/>
        /// <returns></returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            value.EnsureNotNull(nameof(value));
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// Returns hash from string.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="hashAlgorithm">Hash algorithm.</param>
        /// <param name="encoding">Encoding. Default value: UTF8.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="EncoderFallbackException"/>
        /// <returns></returns>
        public static byte[] GetHash(this string value, HashAlgorithm hashAlgorithm, Encoding encoding = null)
        {
            return value.ToBytes(encoding).GetHash(hashAlgorithm);
        }

        /// <summary>
        /// Gets hash from string in string format.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="hashAlgorithm">Hash algorithm.</param>
        /// <param name="encoding">Encoding. Default: UTF8.</param>
        /// <param name="format">Format. Default: X2 (hex).</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static string GetStringHash(this string value, HashAlgorithm hashAlgorithm, Encoding encoding = null, string format = "X2")
        {
            format.EnsureNotNull(nameof(format));
            var sb = new StringBuilder();
            value.GetHash(hashAlgorithm, encoding).ForEach(x => sb.Append(x.ToString(format)));

            return sb.ToString();
        }

        /// <summary>
        /// Gets byte array from string in base64 format.
        /// </summary>
        /// <param name="base64string">String.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] FromBase64(this string base64string)
        {
            base64string.EnsureNotNull(nameof(base64string));
            return Convert.FromBase64String(base64string);
        }

        /// <summary>
        /// Gets string value from string base 64 value.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="encoding">Encoding.</param>
        /// <returns></returns>
        public static string FromBase64String(this string value, Encoding encoding = null)
        { 
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetString(value.FromBase64());
        }
    }
}
