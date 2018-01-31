using System;
using System.Xml.Linq;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies the logical conjunction of two CAML clauses.
        /// </summary>
        /// <param name="leftPart">the left part of the join</param>
        /// <param name="rightPart">the right part of the join</param>
        /// <returns>a new CAML And element</returns>
        public static string And(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.And, leftPart + rightPart);
        }

        /// <summary>
        ///     Specifies that the value of a given field begins with the specified value.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <param name="valueElement">a CAML Value element</param>
        /// <returns>a new CAML BeginsWith element</returns>
        public static string BeginsWith(string fieldRefElement, string valueElement)
        {
            return Tag(Resources.Resources.BeginsWith, fieldRefElement + valueElement);
        }

        /// <summary>
        ///     Specifies that the value of a given field contains the specified value.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <param name="valueElement">a CAML Value element</param>
        /// <returns>a new CAML Contains element</returns>
        public static string Contains(string fieldRefElement, string valueElement)
        {
            return Tag(Resources.Resources.Contains, fieldRefElement + valueElement);
        }

        /// <summary>
        ///     Tests the equality of two CAML clauses.
        /// </summary>
        /// <param name="leftPart">the left part of the expression</param>
        /// <param name="rightPart">the right part of expression</param>
        /// <returns>a new CAML EQ element</returns>
        public static string Eq(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Eq, leftPart + rightPart);
        }

        /// <summary>
        ///     Tests whether the left expression is greater than or equal to the right.
        /// </summary>
        /// <param name="leftPart">the left expression</param>
        /// <param name="rightPart">the right expression</param>
        /// <returns>a new CAML GEQ element</returns>
        public static string Geq(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Geq, leftPart + rightPart);
        }

        /// <summary>
        ///     Tests whether the left expression is greater than the right.
        /// </summary>
        /// <param name="leftPart">the left expression</param>
        /// <param name="rightPart">the right expression</param>
        /// <returns>a new CAML GT element</returns>
        public static string Gt(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Gt, leftPart + rightPart);
        }

        /// <summary>
        ///     Determines whether a given field contains a value.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <returns>a new CAML IsNotNull element</returns>
        public static string IsNotNull(string fieldRefElement)
        {
            return Tag(Resources.Resources.IsNotNull, fieldRefElement);
        }

        /// <summary>
        ///     Determines whether a given field is null.
        /// </summary>
        /// <remarks>Converse of IsNotNull</remarks>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <returns>a new CAML IsNull element</returns>
        public static string IsNull(string fieldRefElement)
        {
            return Tag(Resources.Resources.IsNull, fieldRefElement);
        }

        /// <summary>
        ///     Tests whether the left expression is less than or equal to the right.
        /// </summary>
        /// <param name="leftPart">the left expression</param>
        /// <param name="rightPart">the right expression</param>
        /// <returns>a new CAML LEQ element</returns>
        public static string Leq(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Leq, leftPart + rightPart);
        }

        /// <summary>
        ///     Special optional child of the Lists element.
        /// </summary>
        /// <remarks>
        ///     When present, this element causes the query to be limited to lists
        ///     with indexed fields.
        /// </remarks>
        /// <param name="fieldID">the guid of the indexed field</param>
        /// <param name="fieldValue">the matching field value</param>
        /// <returns>a new CAML WithIndex element</returns>
        public static string WithIndex(Guid fieldID, string fieldValue)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.FieldId, fieldID.ToString("D")),
                new XAttribute(Resources.Resources.Type, Resources.Resources.Text),
                new XAttribute(Resources.Resources.Value, fieldValue)
            };

            return Base.Tag(Resources.Resources.WithIndex, attributes).ToStringBySettings();
        }

        /// <summary>
        ///     Tests whether the left expression is less than the right.
        /// </summary>
        /// <param name="leftPart">the left expression</param>
        /// <param name="rightPart">the right expression</param>
        /// <returns>a new CAML LT element</returns>
        public static string Lt(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Lt, leftPart + rightPart);
        }

        /// <summary>
        ///     Tests whether the left expression is unequal to the right.
        /// </summary>
        /// <param name="leftPart">the left expression</param>
        /// <param name="rightPart">the right expression</param>
        /// <returns>a new CAML NEQ element</returns>
        public static string Neq(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Neq, leftPart + rightPart);
        }

        /// <summary>
        ///     Specifies the logical disjunction of two CAML expressions.
        /// </summary>
        /// <param name="leftPart">the left part of the logical join</param>
        /// <param name="rightPart">the right part of the logical join</param>
        /// <returns>a new CAML OR element</returns>
        public static string Or(string leftPart, string rightPart)
        {
            return Tag(Resources.Resources.Or, leftPart + rightPart);
        }

        /// <summary>
        ///     Specifies the WHERE part of a query.
        /// </summary>
        /// <param name="s">a CAML string that expresses the WHERE conditions</param>
        /// <returns>a new CAML Where element</returns>
        public static string Where(string s)
        {
            return Tag(Resources.Resources.Where, s);
        }
    }
}