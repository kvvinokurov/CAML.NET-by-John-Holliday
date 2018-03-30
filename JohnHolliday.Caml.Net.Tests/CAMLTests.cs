using System.Xml.Linq;
using NUnit.Framework;

namespace JohnHolliday.Caml.Net.Tests
{
    [TestFixture]
    public class CAMLTests
    {
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