using System.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies whether the value of a list item for the field specified by the FieldRef element is equal to one of the
        ///     values specified by the Values element.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <param name="valueElements">array of CAML Values elemenets</param>
        /// <returns>a new CAML In element</returns>
        /// <remarks>
        ///     Т.к. CAML выражение типа In имеет ограничение на кол-во значений, то в случае превышения парогового кол-ва
        ///     значений оно делится на несколько выражений и объединяется выражением Or.
        /// </remarks>
        public static string In([NotNull] string fieldRefElement, string[] valueElements)
        {
            if (valueElements.Length <= Constants.InChunkSize)
                return In(fieldRefElement, Values(valueElements));

            return
                valueElements.Chunk(Constants.InChunkSize)
                    .Select(chunk => In(fieldRefElement, Values(chunk.ToArray())))
                    .Aggregate(Or);
        }

        /// <summary>
        ///     Specifies whether the value of a list item for the field specified by the FieldRef element is equal to one of the
        ///     values specified by the Values element.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element</param>
        /// <param name="valuesElement">a CAML Value element</param>
        /// <returns>a new CAML In element</returns>
        protected static string In([NotNull] string fieldRefElement, string valuesElement)
        {
            return Tag(Resources.Resources.In, string.Concat(fieldRefElement, valuesElement));
        }

        /// <summary>
        ///     Specifies the Values part of In expression.
        /// </summary>
        /// <param name="valueElements">array of CAML Values elemenets</param>
        /// <returns>a new CAML Values element</returns>
        protected static string Values(string[] valueElements)
        {
            return Tag(Resources.Resources.Values, valueElements.Aggregate(string.Concat));
        }
    }
}