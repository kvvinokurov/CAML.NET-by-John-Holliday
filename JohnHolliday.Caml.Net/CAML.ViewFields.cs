using System;
using System.Linq;
using JohnHolliday.Caml.Net.Properties;

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
            return ViewFields(fieldNames.Select(FieldRef).ToArray());
        }

        /// <summary>
        ///     ����� ������������ ����� � �������� �����
        /// </summary>
        /// <param name="fieldIds">�������������� �����</param>
        /// <returns>����������� ��������� �����</returns>
        public static string ViewFields(params Guid[] fieldIds)
        {
            return ViewFields(fieldIds.Select(FieldRef).ToArray());
        }

        /// <summary>
        ///     Specifies which fields to include in the query result set.
        /// </summary>
        /// <param name="fieldRefs">an array of CAML FieldRef elements that identify the fields to be included</param>
        /// <returns>a new CAML ViewFields element</returns>
        public static string ViewFields(params string[] fieldRefs)
        {
            var fieldRefElements = fieldRefs.Aggregate(string.Empty, (current, field) => current + field);
            return Tag(Resources.ViewFields, fieldRefElements);
        }
    }
}