using System;
using System.Linq;
using System.Text;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(string listElements)
        {
            return Lists(BaseType.GenericList, listElements, null, false, 0);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="includeHiddenLists">determines whether the query will include hidden lists</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(string listElements, bool includeHiddenLists)
        {
            return Lists(BaseType.GenericList, listElements, null, includeHiddenLists);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="maxListLimit">limits the query to the total number of lists specified.  By default, the limit is 1000.</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(string listElements, int maxListLimit)
        {
            return Lists(BaseType.GenericList, listElements, null, false, maxListLimit);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <param name="includeHiddenLists">determines whether the query will include hidden lists</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(string listElements, string serverTemplate, bool includeHiddenLists)
        {
            return Lists(BaseType.GenericList, listElements, serverTemplate, includeHiddenLists);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType baseType, string listElements)
        {
            return Lists(baseType, listElements, null, false, 0);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType baseType, string listElements, string serverTemplate)
        {
            return Lists(baseType, listElements, serverTemplate, false, 0);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <param name="includeHiddenLists">determines whether the query will include hidden lists</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType baseType, string listElements, string serverTemplate,
            bool includeHiddenLists)
        {
            return Lists(baseType, listElements, serverTemplate, includeHiddenLists, 0);
        }


        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <param name="listsIds">array of lists ids</param>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <param name="includeHiddenLists">determines whether the query will include hidden lists</param>
        /// <param name="maxListLimit">limits the query to the total number of lists specified.  By default, the limit is 1000.</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType? baseType, Guid[] listsIds, string serverTemplate,
            bool? includeHiddenLists, int maxListLimit = 0)
        {
            return Lists(baseType, string.Join(string.Empty, listsIds.Select(List).ToArray()), serverTemplate,
                includeHiddenLists, maxListLimit);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="listsIds">array of lists ids</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(params Guid[] listsIds)
        {
            return Lists(null, listsIds, null, null);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <returns>a new CAML Lists element</returns>
        public static string ListsWithServerTemplate(int serverTemplate)
        {
            return Lists(null, null as string, serverTemplate.ToString(), null);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType baseType)
        {
            return Lists(baseType, null as string, null, null);
        }

        /// <summary>
        ///     Specifies which lists to include in a query.
        /// </summary>
        /// <summary xml:lang="ru">
        ///     ��������� ��� Lists
        /// </summary>
        /// <param name="baseType">limits the query to lists of the specified base type</param>
        /// <param name="listElements">an XML string containing individual list elements</param>
        /// <param name="serverTemplate">
        ///     limits the query to lists of the specified server template, specified as a number - for
        ///     example '101'
        /// </param>
        /// <param name="includeHiddenLists">determines whether the query will include hidden lists</param>
        /// <param name="maxListLimit">limits the query to the total number of lists specified.  By default, the limit is 1000.</param>
        /// <returns>a new CAML Lists element</returns>
        public static string Lists(BaseType? baseType, string listElements, string serverTemplate,
            bool? includeHiddenLists, int maxListLimit = 0)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Lists");

            if (baseType.HasValue)
                stringBuilder.AppendFormat(" BaseType=\"{0}\"", (int) baseType);

            if (!string.IsNullOrEmpty(serverTemplate))
                stringBuilder.AppendFormat(" ServerTemplate=\"{0}\"", serverTemplate);

            if (includeHiddenLists.HasValue)
                stringBuilder.AppendFormat(" Hidden=\"{0}\"", BoolToString(includeHiddenLists.Value));

            stringBuilder.AppendFormat(" MaxListLimit=\"{0}\"", maxListLimit);

            if (!string.IsNullOrEmpty(listElements))
                stringBuilder.AppendFormat(">{0}</Lists>", listElements);
            else
                stringBuilder.AppendFormat("/>");

            return stringBuilder.ToString();
        }
    }
}