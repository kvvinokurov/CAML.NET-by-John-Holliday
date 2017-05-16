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

using Microsoft.SharePoint;

// This sample shows how the CAML.NET framework can be used in 
// a typical scenario where data resides in one or more SharePoint
// lists and you want to create a reusable query to retrieve it.

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    ///     This class demonstrates using the CAML.NET framework directly by using the
    ///     static string conversion methods to produce the desired CAML query string.  Once
    ///     the string is built, it can be applied directly to any SharePoint object that
    ///     understands raw CAML.
    /// </summary>
    public class RawQuerySample
    {
        /// <summary>
        ///     Retrieves all documents of type "Job Sheet" from a given list.
        /// </summary>
        /// <param name="list">the SPList containing the documents</param>
        public static SPListItemCollection GetJobSheets(SPList list)
        {
            // Create a new query object.
            var query = new SPQuery
            {
                // Assign the query string by using the raw CAML.NET string conversion operators.
                Query = CAML.Where(
                    CAML.Eq(
                        CAML.FieldRef("Document Type"),
                        CAML.Value("Job Sheet")
                    )
                )
            };

            // Assign the query string by using the raw CAML.NET string conversion operators.

            // Execute the query to obtain the matching list items.
            return list.GetItems(query);
        }
    }
}