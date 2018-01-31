using System.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies the names of fields to be used for ordering the result set.
        /// </summary>
        /// <param name="fieldRefElements">a CAML string containing a list of CAML FieldRef elements</param>
        /// <returns>a new CAML OrderBy element</returns>
        public static string OrderBy([NotNull] string fieldRefElements)
        {
            return Tag(Resources.Resources.OrderBy, fieldRefElements);
        }

        /// <summary>
        ///     Builds an OrderBy element from an array of FieldRef elements.
        /// </summary>
        /// <param name="args">an array of CAML FieldRef elements</param>
        /// <returns>a new CAML OrderBy element</returns>
        public static string OrderBy(params string[] args)
        {
            var fieldRefElements = args.Aggregate(string.Empty, (current, o) => current + o.ToString());
            return Tag(Resources.Resources.OrderBy, fieldRefElements);
        }
    }
}