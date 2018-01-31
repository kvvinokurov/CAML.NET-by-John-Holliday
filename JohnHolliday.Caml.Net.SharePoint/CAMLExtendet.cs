using Microsoft.SharePoint;

namespace JohnHolliday.Caml.Net
{
    /// <inheritdoc />
    public class CAMLExtendet : CAML
    {
        /// <summary>
        ///     Specifies a ContentTypeId value
        /// </summary>
        /// <param name="contentTypeId">the ContentTypeId value to be expressed in CAML</param>
        /// <returns>a new CAML Value element</returns>
        public static string Value(SPContentTypeId contentTypeId)
        {
            return ValueForContentTypeIdAsString(contentTypeId.ToString());
        }
    }
}