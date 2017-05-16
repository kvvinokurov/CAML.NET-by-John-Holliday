namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies how to handle automatic hyperlinks.
        /// </summary>
        public enum AutoHyperlinkType
        {
            /// <summary>
            ///     Hyperlinks are ignored.
            /// </summary>
            None,

            /// <summary>
            ///     Surround text with &lt;A&gt; tags if the text appears like a hyperlink (for example, www.johnholliday.net),
            ///     but without HTML encoding.
            /// </summary>
            Plain,

            /// <summary>
            ///     Surround text with &lt;A&gt; tags if the text appears like a hyperlink, with HTML encoding.
            /// </summary>
            HTMLEncoded
        }

        /// <summary>
        ///     Use this enumeration to specify the base list type for cross site queries.
        /// </summary>
        public enum BaseType
        {
            /// <summary>
            ///     A generic list.
            /// </summary>
            GenericList,

            /// <summary>
            ///     A document library.
            /// </summary>
            DocumentLibrary,

            /// <summary>
            ///     A discussion forum.
            /// </summary>
            DiscussionForum,

            /// <summary>
            ///     A survey list.
            /// </summary>
            VoteOrSurvey,

            /// <summary>
            ///     An issue tracking list.
            /// </summary>
            IssuesList
        }

        /// <summary>
        ///     Use this enumeration to specify membership types.
        /// </summary>
        public enum MembershipType
        {
            /// <summary>
            ///     Returns all users who are either members of the site or who have browsed to the site as authenticated members of a
            ///     domain group in the site.
            /// </summary>
            SPWebAllUsers,

            /// <summary>
            ///     Returns groups in the site collection.
            /// </summary>
            SPGroup,

            /// <summary>
            ///     Returns groups in the SharePoint web.
            /// </summary>
            SPWebGroups,

            /// <summary>
            ///     Returns
            /// </summary>
            CurrentUserGroups,

            /// <summary>
            ///     Returns all users that have been explicitly added to the web.
            /// </summary>
            SPWebUsers
        }

        /// <summary>
        ///     Use this enumeration to specify the scope of a site data query.
        /// </summary>
        public enum QueryScope
        {
            /// <summary>
            ///     The query considers only the current SPWeb object.
            /// </summary>
            WebOnly,

            /// <summary>
            ///     The query considers all Web sites that are descended from the current SPWeb object.
            /// </summary>
            Recursive,

            /// <summary>
            ///     The query considers all Web sites that are in the same site collection as the current Web site.
            /// </summary>
            SiteCollection
        }

        /// <summary>
        ///     Use this enumeration to specify sorting of field elements.
        /// </summary>
        public enum SortType
        {
            /// <summary>
            ///     Items are sorted in ascending order.
            /// </summary>
            Ascending,

            /// <summary>
            ///     Items are sorted in descending order.
            /// </summary>
            Descending
        }

        /// <summary>
        ///     Specifies options for URL encoding.
        /// </summary>
        public enum UrlEncodingType
        {
            /// <summary>
            ///     Special characters are not encoded.
            /// </summary>
            None,

            /// <summary>
            ///     Convert special characters, such as spaces, to quoted UTF-8 format.
            /// </summary>
            Standard,

            /// <summary>
            ///     Convert special characters to quoted UTF-8 format, but treats the characters as a
            ///     path component of a URL so that forward slashes ("/") are not encoded.
            /// </summary>
            EncodeAsUrl
        }
    }
}