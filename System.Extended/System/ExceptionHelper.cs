namespace System
{
    internal static class ExceptionHelper
    {
        public static void EnsureNotNull(this object obj, string propName)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(propName);
            }
        }
    }
}