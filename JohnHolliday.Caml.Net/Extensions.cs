using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

// ReSharper disable PossibleMultipleEnumeration

namespace JohnHolliday.Caml.Net
{
    internal static class Extensions
    {
        /// <summary>
        ///     Converts a system DateTime value to ISO8601 DateTime format (yyyy-mm-ddThh:mm:ssZ).
        /// </summary>
        /// <summary xml:lang="ru">
        ///     Конвертирует системное DateTime значение в формат ISO8601 (yyyy-mm-ddThh:mm:ssZ)
        /// </summary>
        /// <param name="dateTime">
        ///     A System.DateTime object that represents the system DateTime value in the form mm/dd/yyyy
        ///     hh:mm:ss AM or PM.
        /// </param>
        /// <returns>A string that contains the date and time in ISO8601 DateTime format.</returns>
        public static string CreateISO8601DateTimeFromSystemDateTime(this DateTime dateTime)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(dateTime.Year.ToString("0000"));
            stringBuilder.Append("-");
            stringBuilder.Append(dateTime.Month.ToString("00"));
            stringBuilder.Append("-");
            stringBuilder.Append(dateTime.Day.ToString("00"));
            stringBuilder.Append("T");
            stringBuilder.Append(dateTime.Hour.ToString("00"));
            stringBuilder.Append(":");
            stringBuilder.Append(dateTime.Minute.ToString("00"));
            stringBuilder.Append(":");
            stringBuilder.Append(dateTime.Second.ToString("00"));
            stringBuilder.Append("Z");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            while (source.Any())
            {
                yield return source.Take(chunkSize);
                source = source.Skip(chunkSize);
            }
        }

        /// <summary>
        ///     Bringing to a line based on project settings
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string ToStringBySettings(this XNode node)
        {
            return node.ToString(Constants.SaveOptions);
        }
    }
}