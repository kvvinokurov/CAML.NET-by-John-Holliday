# CAML.NET by John Holliday

Copy from https://camldotnet.codeplex.com

Project Description

A set of .NET language-based tools for creating dynamic, reusable CAML query components. CAML.NET leverages the power and flexibility of the .NET Common Language Runtime (CLR) to build CAML queries dynamically in code while preserving the syntactic structure of the native CAML language.

The power of CAML lies in its flexibility, but that flexibility comes at a cost. Typically, the cost is measured in lost productivity because it forces developers to work without the tools they need to ensure their code meets solution requirements. It also makes it difficult to effectively extend the efforts of others through the encapsulation and data abstraction that would be possible with a stronly-typed managed language like C#.

CAML.NET addresses this problem by providing a rich set of static methods for easily expressing CAML queries and a corresponding set of wrapper classes for executing queries and then binding the results to any .Net object or data structure. Using CAML.NET, developers can build reusable query libraries and derive new queries from existing ones, adding value to their teams with each new assignment. 


Advantages
Avoids hand-editing of literal XML strings in your code.
Eliminates query failures caused by typos and improper casing of elements and attributes.
Each query component is processed as a separate statement with strongly-typed parameters.
Operator and method overloading greatly simplifies the raw CAML schema.
Enables the use of variables instead of literal text to specify query components.
Visual Studio intellisense support while writing queries.
Simplifies the construction of reusable CAML component libraries.
Supports automatic data-binding to any .Net class or data structure.

Additional Resources
Blog http://johnholliday.net
Documentation http://johnholliday.net/download/johnholliday.caml.net.documentation.chm

Installation
Add a reference to the JohnHolliday.Caml.Net assembly.
Add the appropriate using or imports statement to your code file.
Build your query as in the following examples.
Use the resulting string as standard XML.

Using CAML.NET

The following CAML query retrieves a list of items grouped by title, whose content type is "My Content Type" and whose description field is not empty. It also specifies that the result set should be ordered by the _Author, AuthoringDate and AssignedTo fields and that the AssignedTo field shall be in ascending order.

<Query>
   <Where>
      <Or>
         <Eq>
            <FieldRef Name="ContentType" />
            <Value Type="Text">My Content Type</Value>
         </Eq>
         <IsNotNull>
            <FieldRef Name="Description" />
         </IsNotNull>
      </Or>
   </Where>
   <GroupBy Collapse="TRUE">
      <FieldRef Ascending="FALSE" Name="Title" />
   </GroupBy>
   <OrderBy>
      <FieldRef Name="_Author" />
      <FieldRef Name="AuthoringDate" />
      <FieldRef Ascending="TRUE" Name="AssignedTo" />
   </OrderBy>
</Query>


To use this in C#, you would have to convert it to a literal string, taking care to handle the embedded quotation marks, as in:

string simpleQuery = @"<Query><Where><Or><Eq><FieldRef Name=""ContentType"" /><Value Type=""Text"">My Content Type</Value></Eq>
<IsNotNull><FieldRef Name=""Description"" /></IsNotNull></Or></Where>
<GroupBy Collapse=""TRUE""><FieldRef Ascending=""FALSE"" Name=""Title"" /></GroupBy>
<OrderBy><FieldRef Name=""_Author"" /><FieldRef Name=""AuthoringDate"" />
<FieldRef Ascending=""TRUE"" Name=""AssignedTo"" /></OrderBy></Query>";


To reuse this query for another content type, or to add more fields to the result set, or to change the ordering, etc., you would have to either generate a new query, or painstakingly decode the string by hand, possibly introducing typos or other errors along the way.

Here is the same query written in CAML.NET:

string typeName = "My Content Type";
string simpleQuery =
    CAML.Query(
        CAML.Where(
            CAML.Or(
                CAML.Eq(
                    CAML.FieldRef("ContentType"), 
                    CAML.Value(typeName)),
                CAML.IsNotNull(
                    CAML.FieldRef("Description")))),
        CAML.GroupBy(
            true,
            CAML.FieldRef("Title",CAML.SortType.Descending)),
        CAML.OrderBy(
            CAML.FieldRef("_Author"),
            CAML.FieldRef("AuthoringDate"),
            CAML.FieldRef("AssignedTo",CAML.SortType.Ascending))
    );


Once you've assigned the string, you can use it as you would any other XML query string. For instance, the following code applies the query to a site collection.

   SPSiteDataQuery q = new SPSiteDataQuery();
   q.Query = simpleQuery;
   q.ViewFields = CAML.FieldRef("Title") + CAML.FieldRef("ID");
   q.RowLimit = 10;
   DataTable t = SPContext.Current.Web.GetSiteData(q);


Another Example

Here is another example, taken from the ECM team blog. It lists all .bmp files in the site collection that have a height or width over 200 pixels, in descending order by file size.

<Query>
   <Where>
      <And>
         <Eq>
            <FieldRef Name="DocIcon" />
            <Value Type="Computed">bmp</Value>
         </Eq>
         <Or>
            <Gt>
               <FieldRef Name="ImageWidth" />
               <Value Type="Integer">200</Value>
            </Gt>
            <Gt>
               <FieldRef Name="ImageHeight" />
               <Value Type="Integer">200</Value>
            </Gt>
         </Or>
      </And>
   </Where>
   <OrderBy>
      <FieldRef Ascending="FALSE" Name="FileSizeDisplay" />
   </OrderBy>
</Query>


Again, "stringizing" for C# you have:

string queryBitmapImages = @"<Query><Where><And><Eq><FieldRef Name=""DocIcon"" /><Value Type=""Computed"">bmp</Value></Eq>
<Or><Gt><FieldRef Name=""ImageWidth"" /><Value Type=""Integer"">200</Value></Gt>
<Gt><FieldRef Name=""ImageHeight"" /><Value Type=""Integer"">200</Value></Gt></Or></And></Where>
<OrderBy><FieldRef Ascending=""FALSE"" Name=""FileSizeDisplay"" /></OrderBy></Query>";


And in CAML.NET:

string queryBitmapImages = 
    CAML.Query(
        CAML.Where(
            CAML.And(
                CAML.Eq(
                    CAML.FieldRef("DocIcon"),
                    CAML.Value("Computed","bmp")
                ),
                CAML.Or(
                    CAML.Gt(
                        CAML.FieldRef("ImageWidth"),
                        CAML.Value(200)
                    ),
                    CAML.Gt(
                        CAML.FieldRef("ImageHeight"),
                        CAML.Value(200)
                    )
                )
            )
        ),
        CAML.OrderBy(
            CAML.FieldRef("FileSizeDisplay", CAML.SortType.Descending))
    );


Note the use of the overloaded CAML.Value constructor, which simply takes an integer value as an argument. The generated CAML sets the Value type automatically depending on the type of argument you pass in. There are lots of other places in the CAML schema where the .NET CLR can help to reduce that overall surface area and improve developer productivity.
Last edited Dec 19, 2011 at 5:04 PM by jholliday, version 18
