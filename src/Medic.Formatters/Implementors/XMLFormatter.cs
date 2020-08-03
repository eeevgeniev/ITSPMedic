using Medic.Formatters.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Medic.Formatters.Implementors
{
    public class XMLFormatter : IDataFormattable
    {
        public XMLFormatter(bool indent = false)
        {
            Indent = indent;
        }

        public bool Indent { get; set; }

        public string MimeType => "text/xml";

        public async Task<Stream> FormatObject(object model, Stream stream)
        {
            if (stream == default)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            
            if (model == default)
            {
                return default;
            }

            return await Task<Stream>.Run(() =>
            {
                XmlWriterSettings xmlWriterSettings = Indent != false ? new XmlWriterSettings() { Indent = Indent } : null;

                using XmlWriter writer = XmlWriter.Create(stream, xmlWriterSettings);

                Type modelType = model.GetType();

                XmlRootAttribute xmlRootAttribute = modelType.GetCustomAttribute<XmlRootAttribute>();

                writer.WriteStartElement(xmlRootAttribute != default ? xmlRootAttribute.ElementName : modelType.Name);

                WritePropertiesToXml(model, writer);

                writer.WriteEndElement();
                writer.Flush();

                return stream;
            });
        }

        private PropertyInfo[] GetProperties(object model)
        {
            if (model == default)
            {
                return default;
            }

            return model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private void WritePropertiesToXml(object model, XmlWriter writer)
        {
            PropertyInfo[] properties = GetProperties(model);

            if (properties == default)
            {
                return;
            }

            List<PropertyInfo> notAttributeProperties = new List<PropertyInfo>();
            Type stringType = typeof(string);

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsValueType || property.PropertyType == stringType)
                {
                    XmlAttributeAttribute xmlAttribute = property
                        .GetCustomAttribute<XmlAttributeAttribute>();

                    if (xmlAttribute != default && !IsDefault(property.GetValue(model)))
                    {
                        writer.WriteStartAttribute(!string.IsNullOrWhiteSpace(xmlAttribute.AttributeName) ? xmlAttribute.AttributeName : property.Name);

                        WriteValue(property.GetValue(model), writer);

                        writer.WriteEndAttribute();

                        continue;
                    }
                }

                notAttributeProperties.Add(property);
            }

            foreach (PropertyInfo property in notAttributeProperties)
            {
                if (property.PropertyType.IsValueType || property.PropertyType == stringType)
                {
                    XmlElementAttribute xmlElementAttribute = property.GetCustomAttribute<XmlElementAttribute>();

                    if (!IsDefault(property.GetValue(model)))
                    {
                        writer.WriteStartElement(
                        xmlElementAttribute != default && !string.IsNullOrWhiteSpace(xmlElementAttribute.ElementName) ?
                        xmlElementAttribute.ElementName :
                        property.Name);

                        WriteValue(property.GetValue(model), writer);

                        writer.WriteEndElement();
                    }
                }
                else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    XmlElementAttribute xmlElementAttribute = property.GetCustomAttributes<XmlElementAttribute>().FirstOrDefault();

                    IEnumerable values = property.GetValue(model) as IEnumerable;

                    if (values != default)
                    {
                        foreach (object value in values)
                        {
                            writer.WriteStartElement(
                            xmlElementAttribute != default && !string.IsNullOrWhiteSpace(xmlElementAttribute.ElementName) ?
                            xmlElementAttribute.ElementName :
                            property.Name);

                            WritePropertiesToXml(value, writer);

                            writer.WriteEndElement();
                        }
                    }
                }
                else if (property.PropertyType.IsClass)
                {
                    object value = property.GetValue(model);

                    if (value != null)
                    {
                        XmlElementAttribute xmlElementAttribute = property.GetCustomAttributes<XmlElementAttribute>().FirstOrDefault();

                        writer.WriteStartElement(
                            xmlElementAttribute != default && !string.IsNullOrWhiteSpace(xmlElementAttribute.ElementName) ?
                            xmlElementAttribute.ElementName :
                            property.Name);

                        WritePropertiesToXml(property.GetValue(model), writer);

                        writer.WriteEndElement();
                    }
                }
            }
        }

        private void WriteValue(object value, XmlWriter writer)
        {
            if (value == null)
            {
                writer.WriteValue(null);
            }
            
            Type valueType = value.GetType();

            if (valueType == typeof(int))
            {
                writer.WriteValue((int)value);
            }
            else if (valueType == typeof(uint))
            {
                writer.WriteValue((uint)value);
            }
            else if (valueType == typeof(short))
            {
                writer.WriteValue((short)value);
            }
            else if (valueType == typeof(ushort))
            {
                writer.WriteValue((ushort)value);
            }
            else if (valueType == typeof(byte))
            {
                writer.WriteValue((byte)value);
            }
            else if (valueType == typeof(sbyte))
            {
                writer.WriteValue((sbyte)value);
            }
            else if (valueType == typeof(long))
            {
                writer.WriteValue((long)value);
            }
            else if (valueType == typeof(ulong))
            {
                writer.WriteValue((decimal)(ulong)value);
            }
            else if (valueType == typeof(decimal))
            {
                writer.WriteValue((decimal)value);
            }
            else if (valueType == typeof(float))
            {
                writer.WriteValue((float)value);
            }
            else if (valueType == typeof(double))
            {
                writer.WriteValue((double)value);
            }
            else if (valueType == typeof(bool))
            {
                writer.WriteValue((bool)value);
            }
            else if (valueType == typeof(DateTime))
            {
                writer.WriteValue((DateTime)value);
            }
            else
            {
                writer.WriteValue(value.ToString());
            }
        }

        private bool IsDefault(object value)
        {
            return value == null;
        }
    }
}
