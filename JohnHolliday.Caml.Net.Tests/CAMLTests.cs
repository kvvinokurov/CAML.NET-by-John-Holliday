using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using SPMeta2.Enumerations;

namespace JohnHolliday.Caml.Net.Tests
{
    [TestFixture]
    public class CAMLTests
    {
        [Test]
        public void OrderBy_SendManyFieldRefsInOneString_DoesNotThrow()
        {
            const string orderByString = @"<FieldRef Name=""ID1"" /><FieldRef Name=""ID2"" /><FieldRef Name=""ID3"" />";
            var correctResult = $"<OrderBy>{orderByString}</OrderBy>";
            var res = CAML.OrderBy(orderByString);
            Assert.AreEqual(correctResult, res);
        }

        [Test]
        public void Tag_ComplicatedQuery_DoesNotThrowXmlException()
        {
            Assert.DoesNotThrow(() =>
            {
                var fieldRefId = CAML.FieldRef(BuiltInInternalFieldNames.ID);
                var orderByAsCaml = CAML.OrderBy(
                    CAML.FieldRef(BuiltInInternalFieldNames.ID, CAML.SortType.Ascending)
                );

                var viewFields = new List<string>
                {
                    BuiltInInternalFieldNames.ID,
                    BuiltInInternalFieldNames.Title
                };
                var viewFieldsAsCaml = CAML.ViewFieldsByFieldNames(viewFields.ToArray());

                const int maxRowLimit = 1000;
                var rowLimitAsCaml = CAML.RowLimit(maxRowLimit);

                const int startId = 1;
                const int endId = maxRowLimit;

                CAML.View(
                    string.Concat(
                        CAML.Query(
                            string.Concat(
                                CAML.Where(
                                    CAML.And(
                                        CAML.Geq(
                                            fieldRefId,
                                            CAML.Value(startId)
                                        ),
                                        CAML.Leq(
                                            fieldRefId,
                                            CAML.Value(endId)
                                        )
                                    )
                                ),
                                orderByAsCaml
                            )
                        ),
                        viewFieldsAsCaml,
                        rowLimitAsCaml
                    )
                );
            });
        }

        [Test]
        public void Tag_WithChildXmlElement_ReturnCorrectStringValue()
        {
            var childTag = CAML.Tag(TestData.TagName, TestData.Value);
            var parentTag = CAML.Base.Tag(TestData.TagName, childTag, null);
            var parentTagAsString = parentTag.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual(
                $@"<{TestData.TagName}><{TestData.TagName}>{TestData.Value}</{TestData.TagName}></{TestData.TagName}>",
                parentTagAsString);
        }
    }
}