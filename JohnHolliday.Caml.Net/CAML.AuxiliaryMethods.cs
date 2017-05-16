using JohnHolliday.Caml.Net.Properties;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Convert bool value to CAML string value
        /// </summary>
        /// <param name="boolValue">Bool value</param>
        /// <returns>Bool as CAML string value - TRUE / FALSE</returns>
        public static string BoolToString(bool boolValue)
        {
            return boolValue ? Resources.TRUE : Resources.FALSE;
        }

        /// <summary>
        ///     Creates a "safe" identifier for use in CAML expressions.
        /// </summary>
        /// <remarks>
        ///     This method replaces blank spaces with the "_x0020_" token.
        /// </remarks>
        /// <param name="identifier">the identifier to be tokenized</param>
        /// <returns>a tokenized version of the identifier</returns>
        public static string SafeIdentifier(string identifier)
        {
            return identifier.Replace(" ", "_x0020_");
        }
    }
}