using System.Xml.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Identifies a field reference for grouping.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <returns>a new CAML GroupBy element</returns>
        public static string GroupBy([NotNull] string fieldRefElement)
        {
            return GroupBy(fieldRefElement, false);
        }

        /// <summary>
        ///     Identifies a field reference for grouping and specifies whether to collapse the group.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <param name="bCollapse">whether to collapse the group</param>
        /// <returns>a new CAML GroupBy element</returns>
        public static string GroupBy([NotNull] string fieldRefElement, bool bCollapse)
        {
            return Base.Tag(
                    Resources.Resources.GroupBy, fieldRefElement,
                    new XAttribute(Resources.Resources.Collapse, BoolToString(bCollapse)))
                .ToStringBySettings();
        }
    }
}