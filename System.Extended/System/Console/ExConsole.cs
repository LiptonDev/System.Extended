using System.Collections.Generic;
using System.ComponentModel;

namespace System
{
    /// <summary>
    /// Extended console.
    /// </summary>
    public static class ExConsole
    {
        static readonly List<Type> supportedTypes;

        static ExConsole()
        {
            supportedTypes = new List<Type>
        {
            typeof(bool),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
        };
        }

        /// <summary>
        /// Writing colored text.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="foreground">Foreground color.</param>
        /// <param name="background">Background color.</param>
        public static void ColoredText(string text, ConsoleColor foreground, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Read <typeparamref name="T"/> type from console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ReadLine<T>(string placeholder = null)
        {
            var type = typeof(T);

            if (!supportedTypes.Contains(type))
            {
                throw new NotSupportedException($"type {type} is not supported");
            }

            var converter = TypeDescriptor.GetConverter(type);

            while (true)
            {
                if (placeholder != null)
                {
                    Console.Write(placeholder);
                }

                var read = Console.ReadLine();
                if (converter.IsValid(read))
                {
                    return (T)converter.ConvertFromString(read);
                }
            }

            return default;
        }

        /// <summary>
        /// Read <typeparamref name="T"/> type from console with predicate and conversion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Predicate.</param>
        /// <param name="converter">Converter.</param>
        /// <param name="placeholder">Placeholder.</param>
        /// <returns></returns>
        public static T ReadLine<T>(Predicate<string> predicate, Converter<string, T> converter, string placeholder = null)
        {
            while (true)
            {
                if (placeholder != null)
                {
                    Console.Write(placeholder);
                }

                var read = Console.ReadLine();
                if (predicate(read))
                {
                    return converter(read);
                }
            }
        }
    }
}