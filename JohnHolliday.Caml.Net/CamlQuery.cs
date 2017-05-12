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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace JohnHolliday.Caml.Net
{
    /// <summary>
    ///     A wrapper class for binding query data.
    /// </summary>
    /// <remarks>
    ///     This class is implemented as an attribute so that CAML queries
    ///     can be attached to other objects such as list and site definitions.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CamlQuery : Attribute, ICamlQuery
    {
        /// <summary>
        ///     The CAML string that defines the query scope.
        /// </summary>
        private string m_listsXml = string.Empty;

        /// <summary>
        ///     The CAML string that defines the query, for example:
        ///     <![CDATA[<Where><Contains><FieldRef Name="Author"/><Value Type="Text">Holliday</Value></Contains></Where>]]>
        /// </summary>
        private string m_queryXml = string.Empty;

        /// <summary>
        ///     The CAML string that defines the fields that should be included in the query results.
        /// </summary>
        private string m_viewFieldsXml = string.Empty;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public CamlQuery()
        {
        }

        /// <summary>
        ///     Constructor that accepts a single string argument that
        ///     specifies the underlying CAML query to be used.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="query">the CAML query string</param>
        public CamlQuery(string query)
        {
            QueryXml = query;
        }

        /// <summary>
        ///     Extended constructor that accepts the CAML query string
        ///     along with a variable length list of field references.
        /// </summary>
        /// <param name="query">the CAML query string</param>
        /// <param name="viewFields">a list of FieldRef clauses that specify which fields to include in the result set</param>
        public CamlQuery(string query, params string[] viewFields)
        {
            m_queryXml = query;
            var sb = new StringBuilder();
            foreach (var field in viewFields)
                sb.Append(field);
            ViewFieldsXml = sb.ToString();
        }

        /// <summary>
        ///     This method gives an example of how to construct CamlQuery objects
        ///     using the constructor that accepts the entire query string.
        /// </summary>
        /// <remarks>
        ///     Note that you simply append the GroupBy and OrderBy clauses to the
        ///     query string.
        /// </remarks>
        public static void Example()
        {
            var q = new CamlQuery(
                CAML.Where(
                    CAML.Contains(
                        CAML.FieldRef("Author"),
                        CAML.Value("Holliday")
                        )) +
                CAML.GroupBy(
                    CAML.FieldRef("Title")) +
                CAML.OrderBy(
                    CAML.FieldRef("Title", CAML.SortType.Ascending),
                    CAML.FieldRef("Author", CAML.SortType.Descending))
                );
        }

        /// <summary>
        ///     Standard override for string conversion.
        /// </summary>
        /// <returns>the query associated with this CAML instance</returns>
        public override string ToString()
        {
            return QueryXml + ViewFieldsXml;
        }

        /// <summary>
        ///     Implicit string conversion support.
        /// </summary>
        public static implicit operator string(CamlQuery caml)
        {
            return caml.ToString();
        }

        /// <summary>
        ///     A static method for quickly retrieving items from a list based on a query string.
        /// </summary>
        /// <param name="list">the list containing the items</param>
        /// <param name="queryXml">the query xml</param>
        /// <returns>the collection of matching items</returns>
        public static IList<SPListItem> Fetch(SPList list, string queryXml)
        {
            var query = new CamlQuery(queryXml);
            return query.Fetch(list);
        }

        #region ICamlQuery Members

        /// <summary>
        ///     Gets or sets the query string for this instance.
        /// </summary>
        /// <remarks>
        ///     The QueryXml string includes the Where clause and any OrderBy
        ///     or GroupBy qualifiers.  When deriving a class from CamlQuery,
        ///     you can override this property to supply a custom query string.
        /// </remarks>
        public virtual string QueryXml
        {
            get { return m_queryXml; }
            set { m_queryXml = value; }
        }

        /// <summary>
        ///     Gets or sets the Lists clause for this instance.
        /// </summary>
        public virtual string ListsXml
        {
            get { return m_listsXml; }
            set { m_listsXml = value; }
        }

        /// <summary>
        ///     Gets or sets the ViewFields clause for this instance.
        /// </summary>
        public virtual string ViewFieldsXml
        {
            get { return m_viewFieldsXml; }
            set { m_viewFieldsXml = value; }
        }

        /// <summary>
        ///     Executes the query against a site collection.
        /// </summary>
        public IList<SPListItem> Fetch(SPSite site)
        {
            return Fetch(site.OpenWeb(), CAML.QueryScope.SiteCollection);
        }

        /// <summary>
        ///     Executes the query against a website.
        /// </summary>
        public IList<SPListItem> Fetch(SPWeb web)
        {
            return Fetch(web, CAML.QueryScope.WebOnly);
        }

        /// <summary>
        ///     Creates and initializes an SPQuery object.
        /// </summary>
        public SPQuery CreateQuery()
        {
            var query = new SPQuery
            {
                Query = QueryXml,
                ViewFields = ViewFieldsXml
            };
            return query;
        }

        /// <summary>
        ///     Creates and initializes an SPSiteDataQuery object for a given scope.
        /// </summary>
        public SPSiteDataQuery CreateSiteDataQuery(CAML.QueryScope scope)
        {
            var query = new SPSiteDataQuery
            {
                Query = QueryXml,
                ViewFields = ViewFieldsXml,
                Lists = ListsXml
            };

            // Only use the Webs clause if the scope is different than the default.
            if (scope != CAML.QueryScope.WebOnly)
            {
                query.Webs = CAML.Webs(scope);
            }
            return query;
        }

        /// <summary>
        ///     Retrieves a collection of list items from a SharePoint web using the attached query.
        /// </summary>
        /// <remarks>The query considers</remarks>
        /// <param name="web">the web from which to fetch the items</param>
        /// <param name="scope">specifies the desired query scope</param>
        /// <returns>a list containing the resulting items</returns>
        public IList<SPListItem> Fetch(SPWeb web, CAML.QueryScope scope)
        {
            var items = new List<SPListItem>();
            try
            {
                // Create the query.
                var query = CreateSiteDataQuery(scope);

                // Execute the query.
                DataTable table = web.GetSiteData(query);

                // Convert the resulting table into a generic list
                // of SPListItem instances.
                foreach (DataRow row in table.Rows)
                {
                    var listGuid = new Guid(row["ListId"].ToString());
                    var itemIndex = int.Parse(row["ID"].ToString()) - 1;

                    try
                    {
                        var itemList = web.Lists[listGuid];
                        items.Add(itemList.Items[itemIndex]);
                    }
                    catch (Exception x)
                    {
                        var s = x.Message;
                    }
                }
            }
            catch (Exception x)
            {
                var s = x.Message;
            }
            return items;
        }

        /// <summary>
        ///     Executes the query against a list.
        /// </summary>
        public IList<SPListItem> Fetch(SPList list)
        {
            var items = new List<SPListItem>();
            try
            {
                // Fetch the items.
                items.AddRange(list.GetItems(CreateQuery()).Cast<SPListItem>());
            }
            catch
            {
                // ignored
            }

            return items;
        }

        /// <summary>
        ///     Executes the query against a website for a given scope and then binds to a specified object class.
        /// </summary>
        public IList<T> Fetch<T>(SPWeb web, CAML.QueryScope scope) where T : new()
        {
            IList<T> result = new List<T>();
            const BindingFlags flags =
                BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var item in Fetch(web, scope))
            {
                var t = new T();
                foreach (var info in t.GetType().GetFields(flags))
                {
                    foreach (var field in (ICamlField[]) info.GetCustomAttributes(typeof (CamlField), false))
                    {
                        field.SetValue(t, item, info);
                    }
                }
                result.Add(t);
            }
            return result;
        }

        /// <summary>
        ///     Executes the query against a given site collection and then binds to a specified object class.
        /// </summary>
        public IList<T> Fetch<T>(SPSite site) where T : new()
        {
            IList<T> result = new List<T>();
            var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var item in Fetch(site))
            {
                var t = new T();
                foreach (var info in t.GetType().GetFields(flags))
                {
                    foreach (var field in (ICamlField[]) info.GetCustomAttributes(typeof (CamlField), false))
                    {
                        field.SetValue(t, item, info);
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     Executes the query against a given SPWeb and binds to a specified object class.
        /// </summary>
        public IList<T> Fetch<T>(SPWeb web) where T : new()
        {
            return Fetch<T>(web, CAML.QueryScope.WebOnly);
        }


        /// <summary>
        ///     Executes the query against a given list and then binds to a specified object class.
        /// </summary>
        public IList<T> Fetch<T>(SPList list) where T : new()
        {
            IList<T> result = new List<T>();
            var flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var item in Fetch(list))
            {
                var t = new T();
                foreach (var info in t.GetType().GetFields(flags))
                {
                    foreach (var field in (ICamlField[]) info.GetCustomAttributes(typeof (CamlField), false))
                    {
                        field.SetValue(t, item, info);
                    }
                }
                result.Add(t);
            }
            return result;
        }

        /// <summary>
        ///     Determines whether a column should be bound to a data grid.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsBindableColumn(DataColumn col)
        {
            if (col.ColumnName.Equals("ListId") ||
                col.ColumnName.Equals("WebId"))
                return false;
            return true;
        }

        /// <summary>
        ///     Binds this query to an SPGridView control.
        /// </summary>
        /// <param name="web"></param>
        /// <param name="gridView"></param>
        /// <param name="query"></param>
        /// <param name="initColumns"></param>
        private void BindToGridView(SPWeb web, SPGridView gridView, SPSiteDataQuery query, bool initColumns)
        {
            // Execute the query.
            DataTable table = web.GetSiteData(query);

            // Initialize the gridview columns, if requested
            if (initColumns)
            {
                gridView.AutoGenerateColumns = false;
                gridView.Columns.Clear();

                foreach (DataColumn column in table.Columns)
                {
                    if (IsBindableColumn(column))
                    {
                        var col = new BoundField
                        {
                            DataField = column.ColumnName,
                            HeaderText = string.IsNullOrEmpty(column.Caption) ? column.ColumnName : column.Caption
                        };
                        gridView.Columns.Add(col);
                    }
                }
            }

            // Bind the data to the view.
            gridView.DataSource = table;
            gridView.DataBind();
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        /// <remarks>
        ///     Optionally initializes the gridview columns using the fields associated
        ///     with this query.
        /// </remarks>
        /// <param name="gridView">the gridView to bind to</param>
        /// <param name="web">the web containing the data</param>
        /// <param name="scope">the desired query scope</param>
        /// <param name="initColumns">whether to initialize the gridview columns</param>
        public void DataBind(SPGridView gridView, SPWeb web, CAML.QueryScope scope, bool initColumns)
        {
            BindToGridView(web, gridView, CreateSiteDataQuery(scope), initColumns);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPWeb web, CAML.QueryScope scope)
        {
            DataBind(gridView, web, scope, true);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPWeb web)
        {
            DataBind(gridView, web, CAML.QueryScope.SiteCollection, true);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView)
        {
            DataBind(gridView, SPContext.Current.Web);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPSite site, bool initColumns)
        {
            DataBind(gridView, site.OpenWeb(), CAML.QueryScope.SiteCollection, initColumns);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPSite site)
        {
            DataBind(gridView, site, true);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPList list, bool initColumns)
        {
            var query = CreateSiteDataQuery(CAML.QueryScope.WebOnly);
            query.Lists = CAML.Lists(CAML.List(list.ID));
            BindToGridView(list.ParentWeb, gridView, query, initColumns);
        }

        /// <summary>
        ///     Executes the query and binds the results to a gridview.
        /// </summary>
        public void DataBind(SPGridView gridView, SPList list)
        {
            DataBind(gridView, list, true);
        }

        #endregion
    }
}