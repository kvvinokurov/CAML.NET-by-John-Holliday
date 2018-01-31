using System.Xml.Linq;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies a global site property.
        /// </summary>
        /// <param name="propertyName">the name of the property to be retrieved</param>
        /// <returns>a new CAML ProjectProperty element</returns>
        public static string ProjectProperty(string propertyName)
        {
            return Base.Tag(Resources.Resources.ProjectProperty,
                new XAttribute(Resources.Resources.Select, propertyName)).ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a global site property and a default value.
        /// </summary>
        /// <param name="propertyName">the name of the property to be retrieved</param>
        /// <param name="defaultValue">the default value to use if the property is not found</param>
        /// <returns>a new CAML ProjectProperty element</returns>
        public static string ProjectProperty(string propertyName, string defaultValue)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.Select, propertyName),
                new XAttribute(Resources.Resources.Default, defaultValue)
            };

            return Base.Tag(Resources.Resources.ProjectProperty, attributes).ToStringBySettings();
        }

        /// <summary>
        ///     Specifies a global site property and other options.
        /// </summary>
        /// <param name="propertyName">the name of the property to be retrieved</param>
        /// <param name="defaultValue">the default value to use if the property is not found</param>
        /// <param name="autoHyperlinkType">specifies how to handle hyperlinks <see cref="CAML.AutoHyperlinkType" /></param>
        /// <param name="autoNewLine">
        ///     TRUE to insert &lt;BR&gt; tags into the text stream and to replace multiple spaces with a
        ///     nonbreaking space.
        /// </param>
        /// <param name="expandXML">
        ///     TRUE to re-pass the rendered content through the CAML interpreter, which allows CAML to render
        ///     CAML.
        /// </param>
        /// <param name="htmlEncode">
        ///     TRUE to convert embedded characters so that they are displayed as text in the browser.  In
        ///     other words, characters that could be confused with HTML tags are converted to entities.
        /// </param>
        /// <param name="stripWhiteSpace">
        ///     TRUE to remove white space from the beginning and end of the value returned by the
        ///     element.
        /// </param>
        /// <param name="urlEncodingType">specifies how to handle URL encoding <see cref="CAML.UrlEncodingType" /></param>
        /// <returns></returns>
        public static string ProjectProperty(
            string propertyName,
            string defaultValue,
            AutoHyperlinkType autoHyperlinkType,
            bool autoNewLine,
            bool expandXML,
            bool htmlEncode,
            bool stripWhiteSpace,
            UrlEncodingType urlEncodingType)
        {
            var attributes = new[]
            {
                new XAttribute(Resources.Resources.Select, propertyName),
                new XAttribute(Resources.Resources.Default, defaultValue),
                new XAttribute(
                    autoHyperlinkType == AutoHyperlinkType.Plain
                        ? Resources.Resources.AutoHyperLinkNoEncoding
                        : Resources.Resources.AutoHyperLink,
                    BoolToString(autoHyperlinkType == AutoHyperlinkType.None)
                ),
                new XAttribute(Resources.Resources.AutoNewLine, BoolToString(autoNewLine)),
                new XAttribute(Resources.Resources.HTMLEncode, BoolToString(htmlEncode)),
                new XAttribute(Resources.Resources.StripWS, BoolToString(stripWhiteSpace)),
                new XAttribute(
                    urlEncodingType == UrlEncodingType.EncodeAsUrl
                        ? Resources.Resources.URLEncodeAsURL
                        : Resources.Resources.URLEncode,
                    BoolToString(urlEncodingType != UrlEncodingType.None)
                )
            };

            return Base.Tag(Resources.Resources.ProjectProperty, attributes).ToStringBySettings();
        }
    }
}