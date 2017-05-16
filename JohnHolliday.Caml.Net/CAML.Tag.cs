using System.Collections.Generic;
using System.Text;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Builds an XML string without attributes and attribute values.
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value (can be null)</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag(string tag, string value)
        {
            return Tag(tag, null, null, value);
        }

        /// <summary>
        ///     Builds an XML string with or without attributes and attribute values.
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="attribute">the attribute name (can be null)</param>
        /// <param name="attributeValue">the attribute value (can be null)</param>
        /// <param name="value">the element value (can be null)</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag(string tag, string attribute, string attributeValue, string value)
        {
            return string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(attributeValue)
                ? (string.IsNullOrEmpty(value)
                    ? string.Format("<{0} />", tag)
                    : string.Format("<{0}>{1}</{0}>", tag, value))
                : (string.IsNullOrEmpty(value)
                    ? string.Format("<{0} {1}=\"{2}\" />", tag, attribute, attributeValue)
                    : string.Format("<{0} {1}=\"{2}\">{3}</{0}>", tag, attribute, attributeValue, value));
        }

        /// <summary>
        ///     Handles an arbitrary number of attribute value pairs
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value</param>
        /// <param name="attributeValuePairs">an array of attribute value pairs</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag(string tag, string value, params string[] attributeValuePairs)
        {
            var builder = new StringBuilder("<");
            builder.Append(tag);
            for (var i = 0; i < attributeValuePairs.Length - 1; i += 2)
                builder.AppendFormat(" {0}=\"{1}\"", attributeValuePairs[i], attributeValuePairs[i + 1]);
            if (string.IsNullOrEmpty(value))
                builder.Append(" />");
            else
                builder.AppendFormat(">{0}</{1}>", value, tag);
            return builder.ToString();
        }

        /// <summary>
        ///     Handles an arbitrary number of attribute value pairs
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value</param>
        /// <param name="attributeValuePairs">an dictionary of attribute value pairs</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag(string tag, string value, Dictionary<string, string> attributeValuePairs)
        {
            var builder = new StringBuilder("<");
            builder.Append(tag);
            foreach (var attributeValuePair in attributeValuePairs)
                builder.AppendFormat(" {0}=\"{1}\"", attributeValuePair.Key, attributeValuePair.Value);
            if (string.IsNullOrEmpty(value))
                builder.Append(" />");
            else
                builder.AppendFormat(">{0}</{1}>", value, tag);
            return builder.ToString();
        }
    }
}