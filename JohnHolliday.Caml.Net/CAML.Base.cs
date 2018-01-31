using System;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;

namespace JohnHolliday.Caml.Net
{
    public partial class CAML
    {
        public class Base
        {
            protected Base()
            {
            }

            /// <summary>
            ///     Specifies a value of a given type
            /// </summary>
            /// <param name="valueType">a string describing the data type</param>
            /// <param name="valueAsElement">the value as xElement</param>
            /// <returns>a new CAML Value element</returns>
            public static XElement Value([NotNull] string valueType, XElement valueAsElement)
            {
                return Tag(Resources.Resources.Value, valueAsElement,
                    new XAttribute(Resources.Resources.Type, valueType));
            }

            public static XElement FieldRef([NotNull] string fieldName)
            {
                return Tag(Resources.Resources.FieldRef,
                    new XAttribute(Resources.Resources.Name, SafeIdentifier(fieldName)));
            }

            public static XElement FieldRef(Guid fieldId)
            {
                return Tag(Resources.Resources.FieldRef,
                    new XAttribute(Resources.Resources.ID, fieldId.ToString()));
            }

            public static XElement ViewFields(params XElement[] fieldRefs)
            {
                return Tag(Resources.Resources.ViewFields, fieldRefs);
            }

            public static XElement Tag([NotNull] string tag)
            {
                return Tag(tag, (XElement[]) null, null);
            }

            public static XElement Tag([NotNull] string tag, params XAttribute[] attributes)
            {
                return Tag(tag, (XElement[]) null, attributes);
            }

            public static XElement Tag([NotNull] string tag, XElement valueElement,
                params XAttribute[] attributes)
            {
                return Tag(tag, new[] {valueElement}, attributes);
            }

            public static XElement Tag([NotNull] string tag, string tagValue, params XAttribute[] attributes)
            {
                return TagWithSetValueAction(tag, element =>
                {
                    if (string.IsNullOrEmpty(tagValue))
                        return;

                    element.Value = tagValue;
                }, attributes);
            }

            public static XElement Tag(
                [NotNull] string tag,
                XElement[] valueElements,
                params XAttribute[] attributes)
            {
                return TagWithSetValueAction(tag, element =>
                {
                    if (valueElements == null)
                        return;

                    // ReSharper disable once CoVariantArrayConversion
                    element.Add(valueElements);
                }, attributes);
            }

            private static XElement TagWithSetValueAction(
                [NotNull] string tag,
                Action<XElement> actionToSetTagValue,
                params XAttribute[] attributes)
            {
                if (tag == null)
                    throw new ArgumentNullException(nameof(tag));

                var element = new XElement(tag);

                actionToSetTagValue?.Invoke(element);

                if (attributes == null)
                    return element;

                var attributesArrayWithoutNullElement = attributes.Where(attr => attr != null).ToArray();
                if (attributesArrayWithoutNullElement.Any())
                    // ReSharper disable once CoVariantArrayConversion
                    element.Add(attributesArrayWithoutNullElement);

                return element;
            }
        }
    }
}