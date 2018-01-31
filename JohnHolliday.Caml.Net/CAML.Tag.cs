using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Builds an XML string without attributes and attribute values.
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag([NotNull] string tag)
        {
            return Base.Tag(tag).ToStringBySettings();
        }

        /// <summary>
        ///     Builds an XML string without attributes and attribute values.
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value (can be null)</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag([NotNull] string tag, string value)
        {
            return Base.Tag(tag, value, null).ToStringBySettings();
        }

        /// <summary>
        ///     Builds an XML string with or without attributes and attribute values.
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="attribute">the attribute name (can be null)</param>
        /// <param name="attributeValue">the attribute value (can be null)</param>
        /// <param name="value">the element value (can be null)</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag([NotNull] string tag, string attribute, string attributeValue, string value)
        {
            var attributeElement = !string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(attributeValue)
                ? new XAttribute(attribute, attributeValue)
                : null;

            return Base.Tag(tag, value, attributeElement).ToStringBySettings();
        }

        /// <summary>
        ///     Handles an arbitrary number of attribute value pairs
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value</param>
        /// <param name="attributeValuePairs">an array of attribute value pairs</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag([NotNull] string tag, string value, params string[] attributeValuePairs)
        {
            var attributes = new List<XAttribute>();
            if (attributeValuePairs != null && attributeValuePairs.Length % 2 == 0)
                for (var i = 1; i < attributeValuePairs.Length; i++)
                {
                    var attributeName = attributeValuePairs[i - 1];
                    var attributeValue = attributeValuePairs[i];
                    var attribute = new XAttribute(attributeName, attributeValue);
                    attributes.Add(attribute);
                }

            return Base.Tag(tag, value, attributes.ToArray()).ToStringBySettings();
        }

        /// <summary>
        ///     Handles an arbitrary number of attribute value pairs
        /// </summary>
        /// <param name="tag">the XML element tag</param>
        /// <param name="value">the element value</param>
        /// <param name="attributeValuePairs">an dictionary of attribute value pairs</param>
        /// <returns>an XML string resulting from the combined parameters</returns>
        public static string Tag([NotNull] string tag, string value, Dictionary<string, string> attributeValuePairs)
        {
            var attributes = attributeValuePairs != null && attributeValuePairs.Any()
                ? attributeValuePairs.Select(x => new XAttribute(x.Key, x.Value)).ToArray()
                : null;

            return Base.Tag(tag, value, attributes).ToStringBySettings();
        }
    }
}