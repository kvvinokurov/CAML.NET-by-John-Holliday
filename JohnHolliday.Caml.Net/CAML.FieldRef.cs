using System;
using JohnHolliday.Caml.Net.Properties;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(string fieldName)
        {
            return Tag(Resources.FieldRef, Resources.Name, SafeIdentifier(fieldName), null);
        }

        /// <summary>
        ///     Identifies a CAML field and specifies a sorting.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="sortType">indicates how the resulting field instances shall be sorted</param>
        /// <returns>a new CAML FieldRef element with sorting</returns>
        public static string FieldRef(string fieldName, SortType sortType)
        {
            return Tag(Resources.FieldRef, null, 
                Resources.Ascending, BoolToString(sortType == SortType.Ascending),
                Resources.Name, SafeIdentifier(fieldName));
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(Guid fieldId)
        {
            return Tag(Resources.FieldRef, Resources.ID, fieldId.ToString(), null);
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
            return nullable
                ? Tag(Resources.FieldRef, null,
                    Resources.Ascending,
                    BoolToString(sortType == SortType.Ascending),
                    Resources.ID, fieldId.ToString(),
                    Resources.Nullable, Resources.TRUE)
                : Tag(Resources.FieldRef, null,
                    Resources.Ascending,
                    BoolToString(sortType == SortType.Ascending),
                    Resources.ID, fieldId.ToString());
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
            return nullable
                ? Tag(Resources.FieldRef, null,
                    Resources.ID, fieldId.ToString(),
                    Resources.Nullable, Resources.TRUE)
                : Tag(Resources.FieldRef, null,
                    Resources.ID, fieldId.ToString());
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="nullable"></param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRefWithNullable(string fieldName, bool nullable = false)
        {
            return nullable
                ? Tag(Resources.FieldRef, null,
                    Resources.Name, fieldName,
                    Resources.Nullable, Resources.TRUE)
                : Tag(Resources.FieldRef, null,
                    Resources.Name, fieldName);
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldId">the ID of the referenced field</param>
        /// <param name="lookupId">is Lookup field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(Guid fieldId, bool lookupId)
        {
            return Tag(Resources.FieldRef, null, 
                Resources.ID, fieldId.ToString(), 
                Resources.LookupId, BoolToString(lookupId));
        }

        /// <summary>
        ///     Identifies a CAML field by reference.
        /// </summary>
        /// <param name="fieldName">the name of the referenced field</param>
        /// <param name="lookupId">is Lookup field</param>
        /// <returns>a new CAML FieldRef element</returns>
        public static string FieldRef(string fieldName, bool lookupId)
        {
            return Tag(Resources.FieldRef, null, 
                Resources.Name, fieldName, 
                Resources.LookupId, BoolToString(lookupId));
        }
    }
}