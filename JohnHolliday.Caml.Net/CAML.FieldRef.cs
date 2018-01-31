using System;
using System.Collections.Generic;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef([NotNull] string fieldName)
        {
            return Base.FieldRef(fieldName).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field and specifies a sorting.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="sortType">indicates how the resulting field instances shall be sorted</param>
        /// <returns>a new CAML FieldRef element with sorting</returns>
        public static string FieldRef([NotNull] string fieldName, SortType sortType)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.Ascending, BoolToString(sortType == SortType.Ascending)),
                new XAttribute(Resources.Resources.Name, SafeIdentifier(fieldName))
            };

            return Base.Tag(Resources.Resources.FieldRef, attributes).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(Guid fieldId)
        {
            return Base.FieldRef(fieldId).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field and specifies a sorting.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <param name="sortType">indicates how the resulting field instances shall be sorted</param>
        /// <returns>a new CAML FieldRef element with sorting</returns>
        public static string FieldRef(Guid fieldId, SortType sortType)
        {
            return FieldRef(fieldId, sortType, false);
        }

        /// <summary>
        ///     Identifies a CAML field and specifies a sorting.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <param name="sortType">indicates how the resulting field instances shall be sorted</param>
        /// <param name="nullable"></param>
        /// <returns>a new CAML FieldRef element with sorting</returns>
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static string FieldRef(Guid fieldId, SortType sortType, bool nullable = false)
        {
            var attributes = new List<XAttribute>
            {
                new XAttribute(Resources.Resources.ID, fieldId.ToString()),
                new XAttribute(Resources.Resources.Ascending, BoolToString(sortType == SortType.Ascending))
            };

            if (nullable)
                attributes.Add(new XAttribute(Resources.Resources.Nullable, Resources.Resources.TRUE));

            return Base.Tag(Resources.Resources.FieldRef, attributes.ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <param name="nullable"></param>
        /// <returns>a new CAML FieldRef element</returns>
        // ReSharper disable once MethodOverloadWithOptionalParameter
        public static string FieldRefWithNullable(Guid fieldId, bool nullable = false)
        {
            var attributes = new List<XAttribute>
            {
                new XAttribute(Resources.Resources.ID, fieldId.ToString())
            };

            if (nullable)
                attributes.Add(new XAttribute(Resources.Resources.Nullable, Resources.Resources.TRUE));

            return Base.Tag(Resources.Resources.FieldRef, attributes.ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="nullable"></param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRefWithNullable([NotNull] string fieldName, bool nullable = false)
        {
            var attributes = new List<XAttribute>
            {
                new XAttribute(Resources.Resources.Name, fieldName)
            };

            if (nullable)
                attributes.Add(new XAttribute(Resources.Resources.Nullable, Resources.Resources.TRUE));

            return Base.Tag(Resources.Resources.FieldRef, attributes.ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <param name="lookupId">is Lookup field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(Guid fieldId, bool lookupId)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.ID, fieldId.ToString()),
                new XAttribute(Resources.Resources.LookupId, BoolToString(lookupId))
            };

            return Base.Tag(Resources.Resources.FieldRef, attributes).ToStringBySettings();
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="lookupId">is Lookup field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef([NotNull] string fieldName, bool lookupId)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.Name, fieldName),
                new XAttribute(Resources.Resources.LookupId, BoolToString(lookupId))
            };

            return Base.Tag(Resources.Resources.FieldRef, attributes).ToStringBySettings();
        }
    }
}