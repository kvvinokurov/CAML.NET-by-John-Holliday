using System;
using System.Collections.Generic;
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
            if (fieldRefElements.IndexOf("><", StringComparison.InvariantCultureIgnoreCase) == -1)
                return Tag(Resources.Resources.OrderBy, fieldRefElements);

            var list = new List<string>();
            var arrayOfFieldRefs = fieldRefElements.Replace("><", "|")
                .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in arrayOfFieldRefs)
            {
                var tag = element;
                if (tag.IndexOf('<') != 0)
                    tag = $"<{tag}";
                if (tag.LastIndexOf('>') != tag.Length - 1)
                    tag = $"{tag}>";

                list.Add(tag);
            }

            return Base.Tag(Resources.Resources.OrderBy, list.ToArray(), null).ToStringBySettings();
        }

        /// <summary>
        ///     Builds an OrderBy element from an array of FieldRef elements.
        /// </summary>
        /// <param name="args">an array of CAML FieldRef elements</param>
        /// <returns>a new CAML OrderBy element</returns>
        public static string OrderBy(params string[] args)
        {
            //var fieldRefElements = args.Aggregate(string.Empty, (current, o) => current + o.ToString());
            return Base.Tag(Resources.Resources.OrderBy, args, null).ToStringBySettings();
        }
    }
}