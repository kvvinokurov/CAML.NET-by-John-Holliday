using System;
using System.Xml.Linq;
using JetBrains.Annotations;

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
            return Value(Resources.Resources.Text, fieldValue);
        }

        /// <summary>
        ///     Specifies an integer value
        /// </summary>
        /// <param name="fieldValue">the integer value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(int fieldValue)
        {
            return Value(Resources.Resources.Integer, fieldValue.ToString());
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
            return Value(Resources.Resources.Boolean, fieldValue ? "1" : "0");
            //return Value(Resources.Boolean, BoolToString(fieldValue));
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
            return Value(Resources.Resources.DateTime,
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
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.Type, Resources.Resources.DateTime),
                new XAttribute(Resources.Resources.IncludeTimeValue, BoolToString(includeTimeValue))
            };

            return Base.Tag(Resources.Resources.Value, fieldValue.CreateISO8601DateTimeFromSystemDateTime(),
                    attributes)
                .ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a DateTime Today value
        /// </summary>
        /// <returns>a new CAML Value element</returns>
        public static string ValueToday()
        {
            return Base.Value(Resources.Resources.DateTime, Base.Tag(Resources.Resources.Today))
                .ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a DateTime Today value with OffsetDays
        /// </summary>
        /// <returns>a new CAML Value element</returns>
        public static string ValueToday(int offsetDays)
        {
            return Base.Value(
                Resources.Resources.DateTime,
                Base.Tag(Resources.Resources.Today,
                    new XAttribute(Resources.Resources.OffsetDays, offsetDays.ToString()))
            ).ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a DateTime TodayISO value
        /// </summary>
        /// <returns>a new CAML Value element</returns>
        public static string ValueTodayISO()
        {
            return Base.Value(Resources.Resources.DateTime, Base.Tag(Resources.Resources.TodayISO))
                .ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a ContentTypeId value
        /// </summary>
        /// <param name="contentTypeId">the ContentTypeId value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string ValueForContentTypeIdAsString(string contentTypeId)
        {
            return Value(Resources.Resources.ContentTypeId, contentTypeId);
        }

        /// <summary>
        ///     Specifies a value of a given type
        /// </summary>
        /// <param name="valueType">a string describing the data type</param>
        /// <param name="fieldValue">the value formatted as a string</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value([NotNull] string valueType, string fieldValue)
        {
            return Base.Tag(Resources.Resources.Value, fieldValue,
                    new XAttribute(Resources.Resources.Type, valueType))
                .ToStringBySettings();
        }
    }
}