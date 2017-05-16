using JohnHolliday.Caml.Net.Properties;

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
            return Tag(Resources.ProjectProperty, Resources.Select, propertyName, null);
        }

        /// <summary>
        ///     Specifies a global site property and a default value.
        /// </summary>
        /// <param name="propertyName">the name of the property to be retrieved</param>
        /// <param name="defaultValue">the default value to use if the property is not found</param>
        /// <returns>a new CAML ProjectProperty element</returns>
        public static string ProjectProperty(string propertyName, string defaultValue)
        {
            return Tag(Resources.ProjectProperty, null, 
                Resources.Select, propertyName, 
                Resources.Default, defaultValue);
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
        public static string ProjectProperty(string propertyName, string defaultValue,
            AutoHyperlinkType autoHyperlinkType, bool autoNewLine, bool expandXML, bool htmlEncode,
            bool stripWhiteSpace, UrlEncodingType urlEncodingType)
        {
            return Tag(Resources.ProjectProperty, null, 
                Resources.Select, propertyName, 
                Resources.Default, defaultValue,
                autoHyperlinkType == AutoHyperlinkType.Plain
                    ? Resources.AutoHyperLinkNoEncoding
                    : Resources.AutoHyperLink,
                BoolToString(autoHyperlinkType == AutoHyperlinkType.None),
                Resources.AutoNewLine, BoolToString(autoNewLine),
                Resources.HTMLEncode, BoolToString(htmlEncode),
                Resources.StripWS, BoolToString(stripWhiteSpace),
                urlEncodingType == UrlEncodingType.EncodeAsUrl
                    ? Resources.URLEncodeAsURL
                    : Resources.URLEncode,
                BoolToString(urlEncodingType != UrlEncodingType.None)
            );
        }
    }
}