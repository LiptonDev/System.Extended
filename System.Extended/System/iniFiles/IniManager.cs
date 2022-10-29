using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    /// <summary>
    /// .ini file manager.
    /// </summary>
    public class IniManager
    {
        /// <summary>
        /// Path to file.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public IniManager(string iniPath)
        {
            Path = iniPath;
        }

        /// <summary>
        /// Read value.
        /// </summary>
        /// <param name="section">Section.</param>
        /// <param name="key">Key.</param>
        /// <returns></returns>
        public string Read(string section, string key)
        {
            StringBuilder buffer = new StringBuilder(1024);
            GetPrivateString(section, key, null, buffer, 1024, Path);
            return buffer.ToString();
        }

        /// <summary>
        /// Write value.
        /// </summary>
        /// <param name="section">Section.</param>
        /// <param name="key">Key.</param>
        /// <param name="value">New value.</param>
        public void Write(string section, string key, string value)
        {
            WritePrivateString(section, key, value, Path);
        }

        #region dll
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern int WritePrivateString(string section, string key, string str, string path);
        #endregion
    }
}