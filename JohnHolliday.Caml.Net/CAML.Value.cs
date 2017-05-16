using System;
using JohnHolliday.Caml.Net.Properties;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies a string value
        /// </summary>
        /// <param name="fieldValue">the string value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(string fieldValue)
        {
            return Value(Resources.Text, fieldValue);
        }

        /// <summary>
        ///     Specifies an integer value
        /// </summary>
        /// <param name="fieldValue">the integer value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(int fieldValue)
        {
            return Value(Resources.Integer, fieldValue.ToString());
        }

        /// <summary>
        ///     Specifies a boolean value
        /// </summary>
        /// <summary xml:lang="ru">
        ///     Метод формирования значения типа bool
        /// </summary>
        /// <param name="fieldValue">the boolean value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(bool fieldValue)
        {
            return Value(Resources.Boolean, fieldValue ? "1" : "0");
            //return Tag(Resources.Value, Resources.Type, Resources.Boolean, fieldValue.ToString());
        }


        /// <summary>
        ///     Specifies a DateTime value
        /// </summary>
        /// <summary xml:lang="ru">
        ///     Метод формирования значения в формате DateTime
        /// </summary>
        /// <param name="fieldValue">the DateTime value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(DateTime fieldValue)
        {
            //return Tag(Resources.Value, Resources.Type, Resources.DateTime, fieldValue.ToString());
            return Value(Resources.DateTime,
                fieldValue.CreateISO8601DateTimeFromSystemDateTime());
        }

        /// <summary>
        ///     Specifies a DateTime value
        /// </summary>
        /// <param name="fieldValue">the DateTime value to be expressed in CAML</param>
        /// <param name="includeTimeValue">add IncludeTimeValue attribute value</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(DateTime fieldValue, bool includeTimeValue)
        {
            return Tag(Resources.Value, fieldValue.CreateISO8601DateTimeFromSystemDateTime(),
                Resources.Type, Resources.DateTime,
                Resources.IncludeTimeValue, BoolToString(includeTimeValue));
        }

        /// <summary>
        ///     Specifies a DateTime Today value
        /// </summary>
        /// <returns>a new CAML Value element</returns>
        public static string ValueToday()
        {
            return Value(Resources.DateTime, Tag(Resources.Today, null));
        }

        /// <summary>
        ///     Specifies a DateTime TodayISO value
        /// </summary>
        /// <returns>a new CAML Value element</returns>
        public static string ValueTodayISO()
        {
            return Value(Resources.DateTime, Tag(Resources.TodayISO, null));
        }


        /// <summary>
        ///     Specifies a ContentTypeId value
        /// </summary>
        /// <param name="contentTypeId">the ContentTypeId value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string ValueForContentTypeIdAsString(string contentTypeId)
        {
            return Value(Resources.ContentTypeId, contentTypeId);
        }

        /// <summary>
        ///     Specifies a value of a given type
        /// </summary>
        /// <param name="valueType">a string describing the data type</param>
        /// <param name="fieldValue">the value formatted as a string</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(string valueType, string fieldValue)
        {
            return Tag(Resources.Value, Resources.Type, valueType, fieldValue);
        }
    }
}