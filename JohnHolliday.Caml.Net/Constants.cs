using System.Xml.Linq;

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    ///     CAML constants
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        ///     Chunk size for In tag
        /// </summary>
        public const int InChunkSize = 500;

        /// <summary>
        ///     xNode ToString SaveOptions settings
        /// </summary>
        public const SaveOptions SaveOptions = System.Xml.Linq.SaveOptions.None;
    }
}