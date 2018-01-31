using System.Xml.Linq;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        /// <summary>
        ///     Specifies the membership for a query <see cref="CAML.MembershipType" />.
        /// </summary>
        /// <param name="type">specifies the membership type</param>
        /// <returns>a new CAML Membership element</returns>
        public static string Membership(MembershipType type)
        {
            return Membership(type, null);
        }

        /// <summary>
        ///     Specifies the membership for a query <see cref="CAML.MembershipType" />
        /// </summary>
        /// <param name="type">specifies the membership type</param>
        /// <param name="value">specifies the membership filter value</param>
        /// <returns>a new CAML Membership element</returns>
        public static string Membership(MembershipType type, string value)
        {
            var attributeValueOfMembershipType = GetMembershipNameByType(type);

            return Base.Tag(Resources.Resources.Membership, value, new XAttribute(Resources.Resources.Type, attributeValueOfMembershipType)).ToStringBySettings();
        }

        /// <summary>
        ///     Get Membership type as string <see cref="CAML.MembershipType" />
        /// </summary>
        /// <param name="type">membership type</param>
        /// <returns>membership type as string</returns>
        protected static string GetMembershipNameByType(MembershipType type)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (type)
            {
                case MembershipType.SPWebAllUsers:
                    return Resources.Resources.SPWebAllUsers;
                case MembershipType.SPWebGroups:
                    return Resources.Resources.SPWebGroups;
                case MembershipType.SPWebUsers:
                    return Resources.Resources.SPWebUsers;
                case MembershipType.SPGroup:
                    return Resources.Resources.SPGroup;
                default:
                    return Resources.Resources.CurrentUserGroups;
            }
        }
    }
}