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
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using JohnHolliday.Caml.Net.Properties;

namespace JohnHolliday.Caml.Net.Samples
{
    /// <summary>
    /// This is a simple query that retrieves all events where the "Audience" field
    /// contains a given audience name and the event date is greater or equal to
    /// the current date.
    /// </summary>
    public class FindEventsByAudience : CamlQuery
    {
        /// <summary>
        /// The audience name to match.
        /// </summary>
        private string m_audienceName = string.Empty;

        /// <summary>
        /// The constructor passes the query definition along to the base class, which
        /// evaluates and stored the CAML string used to perform the query when one
        /// of the Fetch() methods is called.
        /// </summary>
        /// <param name="audienceName"></param>
        public FindEventsByAudience(string audienceName)
        {
            m_audienceName = audienceName;
        }

        /// <summary>
        /// The name of the audience to match.
        /// </summary>
        public string AudienceName
        {
            get { return m_audienceName; }
        }

        /// <summary>
        ///  Custom override that gets or sets the QueryXml.
        /// </summary>
        public override string QueryXml
        {
            get
            {
                // construct the CAML query string
                return CAML.Where(CAML.And(
                    CAML.Contains(CAML.FieldRef("Audience"), CAML.Value(this.AudienceName)),
                    CAML.Geq(CAML.FieldRef("EventDate"), CAML.Value(DateTime.Today))));
            }
            set
            {
                base.QueryXml = value;
            }
        }

        /// <summary>
        /// This static method shows how this class could be used in an application.
        /// </summary>
        public static void Test()
        {
            // Create an instance of the query that finds events for the "Employee" audience.
            FindEventsByAudience queryEmployeeEvents = new FindEventsByAudience("Employee");

            // Create a second instance that finds events for the "VIP" audience.
            FindEventsByAudience queryVIPEvents = new FindEventsByAudience("VIP");

            // Open a web and execute both instances.
            using (SPWeb web = new SPSite("http://localhost").OpenWeb())
            {
                // Get the list of employee events.
                IList<SPListItem> employeeEvents = queryEmployeeEvents.Fetch(web);
                // Get the list of vip events and extend the search to include all subwebs.
                IList<SPListItem> vipEvents = queryVIPEvents.Fetch(web, CAML.QueryScope.Recursive);

                // ... custom code omitted to work with the resulting list items
            }
        }

#region Custom Data Binding Example

        /// <summary>
        /// Defines a class for working with event list items.
        /// </summary>
        private class SpecialEvent
        {
            /// <summary>
            /// Maps the SharePoint "Title" column to the event name.
            /// </summary>
            [CamlField("Title")]
            private string EventName = string.Empty;

            /// <summary>
            /// Maps the SharePoint "Date" column to the event date.
            /// </summary>
            [CamlField("Date")]
            private DateTime EventDate = DateTime.Today;

            public SpecialEvent() { } // needed for reflection

            /// <summary>
            /// Retrieves a list of employee events.
            /// </summary>
            /// <param name="web">the web containing the events list</param>
            /// <returns></returns>
            public static IList<SpecialEvent> FindEmployeeEvents(SPWeb web)
            {
                // Create an instance of the FindByAudience query that filters by employee.
                FindEventsByAudience queryEmployeeEvents = new FindEventsByAudience("Employee");

                // Use the generic Fetch method to bind to the SpecialEvent class.
                return queryEmployeeEvents.Fetch<SpecialEvent>(web);
            }
        }

#endregion

    }
}
