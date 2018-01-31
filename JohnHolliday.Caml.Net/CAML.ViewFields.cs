using System;
using System.Linq;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies which fields to include in the query result set.
        /// </summary>
        /// <param name="fieldNames">an array of field names to be included</param>
        /// <returns>a new CAML ViewFields element</returns>
        public static string ViewFieldsByFieldNames(params string[] fieldNames)
        {
            return Base.ViewFields(fieldNames.Select(Base.FieldRef).ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     ����� ������������ ����� � �������� �����
        /// </summary>
        /// <param name="fieldIds">�������������� �����</param>
        /// <returns>����������� ��������� �����</returns>
        public static string ViewFields(params Guid[] fieldIds)
        {
            return Base.ViewFields(fieldIds.Select(Base.FieldRef).ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     Specifies which fields to include in the query result set.
        /// </summary>
        /// <param name="fieldRefs">an array of CAML FieldRef elements that identify the fields to be included</param>
        /// <returns>a new CAML ViewFields element</returns>
        public static string ViewFields(params string[] fieldRefs)
        {
            var fieldRefElements = fieldRefs.Aggregate(string.Empty, (current, field) => current + field);
            return Tag(Resources.Resources.ViewFields, fieldRefElements);
        }
    }
}