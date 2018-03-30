using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace JohnHolliday.Caml.Net.Tests
{
    [TestFixture]
    public class CAMLBaseTests
    {
        

        [Test]
        public void Tag_AllPropertiesFilled_ReturnCorrectValue()
        {
            var xmlValue = new XElement(TestData.Value);
            var xmlValueAsString = xmlValue.ToString(SaveOptions.None);

            var attr = new XAttribute(TestData.AttributeName, TestData.AttributeValue);

            var xml = CAML.Base.Tag(TestData.TagName, xmlValue, attr);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TestData.TagName} {attr}>{xmlValueAsString}</{TestData.TagName}>", str);
        }

        [Test]
        public void Tag_FilledTagNameAndTextValue_ReturnCorrectValue()
        {
            var xml = CAML.Base.Tag(TestData.TagName, TestData.Value, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TestData.TagName}>{TestData.Value}</{TestData.TagName}>", str);
        }

        [Test]
        public void Tag_FilledTagNameAndXmlValue_ReturnCorrectValue()
        {
            var xmlValue = new XElement(TestData.Value);
            var xmlValueAsString = xmlValue.ToString(SaveOptions.None);

            var xml = CAML.Base.Tag(TestData.TagName, xmlValue, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TestData.TagName}>{xmlValueAsString}</{TestData.TagName}>", str);
        }

        [Test]
        public void Tag_FillOnlyTagName_ReturnCorrectValue()
        {
            var xml = CAML.Base.Tag(TestData.TagName, (XElement[]) null, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TestData.TagName} />", str);
        }

        [Test]
        public void Tag_TagNameIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                CAML.Base.Tag(null, (XElement[]) null, null);
            });
        }
    }
}