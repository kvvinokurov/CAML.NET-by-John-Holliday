using System;
using System.Xml.Linq;
using NUnit.Framework;

namespace JohnHolliday.Caml.Net.Tests
{
    [TestFixture]
    public class CAMLBaseTests
    {
        private const string TagName = "Test";
        private const string Value = "SomeValue";
        private const string AttributeName = "testattribute";
        private const string AttributeValue = "attrval";

        [Test]
        public void Tag_AllPropertiesFilled_ReturnCorrectValue()
        {
            var xmlValue = new XElement(Value);
            var xmlValueAsString = xmlValue.ToString(SaveOptions.None);

            var attr = new XAttribute(AttributeName, AttributeValue);

            var xml = CAML.Base.Tag(TagName, xmlValue, attr);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TagName} {attr}>{xmlValueAsString}</{TagName}>", str);
        }

        [Test]
        public void Tag_FilledTagNameAndTextValue_ReturnCorrectValue()
        {
            var xml = CAML.Base.Tag(TagName, Value, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TagName}>{Value}</{TagName}>", str);
        }

        [Test]
        public void Tag_FilledTagNameAndXmlValue_ReturnCorrectValue()
        {
            var xmlValue = new XElement(Value);
            var xmlValueAsString = xmlValue.ToString(SaveOptions.None);

            var xml = CAML.Base.Tag(TagName, xmlValue, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TagName}>{xmlValueAsString}</{TagName}>", str);
        }

        [Test]
        public void Tag_FillOnlyTagName_ReturnCorrectValue()
        {
            var xml = CAML.Base.Tag(TagName, (XElement[]) null, null);
            var str = xml.ToString(SaveOptions.DisableFormatting);

            Assert.AreEqual($@"<{TagName} />", str);
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