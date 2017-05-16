#region Copyright(c) John F. Holliday, All Rights Reserved.

// -----------------------------------------------------------------------------
// Copyright(c) 2007 John F. Holliday, All Rights Reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//   1.  Redistribution of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//   2.  Redistribution in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//   3.  The name of the author may not be used to endorse or promote products
//       derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
// EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS;
// OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
// OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// -----------------------------------------------------------------------------

#endregion

using System;
using System.Linq;
using JohnHolliday.Caml.Net.Properties;

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    ///     A helper class for working with CAML queries.
    /// </summary>
    public partial class CAML
    {
        /// <summary>
        ///     Tests whether the dates in a recurring event overlap a specified DateTime value.
        /// </summary>
        /// <param name="fieldRefElement">a CAML FieldRef element for the target event date</param>
        /// <param name="valueElement">a CAML Value element containing the date to be tested</param>
        /// <returns>a new CAML DateRangesOverlap element</returns>
        public static string DateRangesOverlap(string fieldRefElement, string valueElement)
        {
            return Tag(Resources.DateRangesOverlap, string.Concat(fieldRefElement, FieldRef("EndDate"), FieldRef("RecurrenceID"), valueElement));
        }

        /// <summary>
        ///     Allows a query to include specific lists, instead of returning all lists of a particular type.
        /// </summary>
        /// <param name="listId">identifies the lists</param>
        /// <returns>a new CAML List element</returns>
        public static string List(Guid listId)
        {
            return Tag(Resources.List, Resources.ID, listId.ToString("D"), null);
        }


        /// <summary>
        ///     Specifies which Web sites to include in the query as specified by the Scope attribute.
        /// </summary>
        /// <param name="scope">specifies the query scope</param>
        /// <returns>a new CAML Webs element</returns>
        public static string Webs(QueryScope scope)
        {
            return Tag(Resources.Webs, Resources.Scope, scope.ToString(), null);
            //return Tag(Resources.Webs, null, Resources.Scope, scope.ToString());
        }

        /// <summary>
        ///     Specifies a custom XML element.
        /// </summary>
        /// <param name="s">a CAML string to be embedded in the element</param>
        /// <returns>a new CAML XML element</returns>
        public static string XML(string s)
        {
            return Tag(Resources.XML, s);
        }

        /// <summary>
        ///     Defines the query for a view <see cref="CAML.View"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>a new CAML Query element</returns>
        public static string Query(string s)
        {
            return Tag(Resources.Query, s);
        }

        /// <summary>
        ///     Specifies the View
        /// </summary>
        /// <param name="s"></param>
        /// <returns>a new CAML View element</returns>
        public static string View(string s)
        {
            return Tag(Resources.View, s);
        }


    }
}