using Medic.Formatters.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Medic.Formatters
{
    public class XMLFormatter : IDataFormattable
    {
        public XMLFormatter(bool indent = false)
        {
            Indent = indent;
        }

        public bool Indent { get; set; }

        public string MimeType => "text/xml";

        public async Task<string> FormatObject(object model)
        {
            if (model == default)
            {
                return default;
            }

            return await Task<string>.Run(() =>
            {
                XmlWriterSettings xmlWriterSettings = Indent != false ? new XmlWriterSettings() { Indent = Indent } : null;

                using MemoryStream memoryStream = new MemoryStream();

                using XmlWriter writer = XmlWriter.Create(memoryStream, xmlWriterSettings);

                Type modelType = model.GetType();

                XmlRootAttribute xmlRootAttribute = modelType.GetCustomAttribute<XmlRootAttribute>();

                writer.WriteStartElement(xmlRootAttribute != default ? xmlRootAttribute.ElementName : modelType.Name);

                WritePropertiesToXml(model, writer);

                writer.WriteEndElement();
                writer.Flush();

                return Encoding.UTF8.GetString(memoryStream.ToArray());
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

                    if (xmlAttribute != default && !isDefault(model, property))
                    {
                        writer.WriteStartAttribute(!string.IsNullOrWhiteSpace(xmlAttribute.AttributeName) ? xmlAttribute.AttributeName : property.Name);

                        WriteValue(model, property, writer);

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

                    if (!isDefault(model, property))
                    {
                        writer.WriteStartElement(
                        xmlElementAttribute != default && !string.IsNullOrWhiteSpace(xmlElementAttribute.ElementName) ?
                        xmlElementAttribute.ElementName :
                        property.Name);

                        WriteValue(model, property, writer);

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

        private void WriteValue(object model, PropertyInfo property, XmlWriter writer)
        {
            var a = property.GetValue(model);

            if (property.PropertyType == typeof(int))
            {
                writer.WriteValue((int)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(int?))
            {
                writer.WriteValue((int?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(uint))
            {
                writer.WriteValue((uint)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(uint?))
            {
                writer.WriteValue((uint?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(short))
            {
                writer.WriteValue((short)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(short?))
            {
                writer.WriteValue((short?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(ushort))
            {
                writer.WriteValue((ushort)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(ushort?))
            {
                writer.WriteValue((ushort?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(byte))
            {
                writer.WriteValue((byte)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(byte?))
            {
                writer.WriteValue((byte?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(sbyte))
            {
                writer.WriteValue((sbyte)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(sbyte?))
            {
                writer.WriteValue((sbyte?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(long))
            {
                writer.WriteValue((long)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(long?))
            {
                writer.WriteValue((long?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(ulong))
            {
                writer.WriteValue((decimal)(ulong)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(ulong?))
            {
                writer.WriteValue((decimal?)(ulong?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(decimal))
            {
                writer.WriteValue((decimal)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(decimal?))
            {
                writer.WriteValue((decimal?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(float))
            {
                writer.WriteValue((float)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(float?))
            {
                writer.WriteValue((float?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(double))
            {
                writer.WriteValue((double)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(double?))
            {
                writer.WriteValue((double?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(bool))
            {
                writer.WriteValue((bool)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(bool?))
            {
                writer.WriteValue((bool?)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                writer.WriteValue((DateTime)property.GetValue(model));
            }
            else if (property.PropertyType == typeof(DateTime?))
            {
                writer.WriteValue((DateTime?)property.GetValue(model));
            }
            else
            {
                object value = property.GetValue(model);

                if (value != null)
                {
                    writer.WriteValue(value.ToString());
                }
                else
                {
                    writer.WriteValue(null);
                }
            }
        }

        private bool isDefault(object model, PropertyInfo property)
        {
            var a = property.GetValue(model);

            if (a == null)
            {
                return true;
            }

            if (property.PropertyType == typeof(int))
            {
                return (int)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(int?))
            {
                return (int?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(uint))
            {
                return (uint)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(uint?))
            {
                return (uint?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(short))
            {
                return (short)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(short?))
            {
                return (short?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(ushort))
            {
                return (ushort)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(ushort?))
            {
                return (ushort?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(byte))
            {
                return (byte)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(byte?))
            {
                return (byte?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(sbyte))
            {
                return (sbyte)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(sbyte?))
            {
                return (sbyte?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(long))
            {
                return (long)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(long?))
            {
                return (long?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(ulong))
            {
                return (decimal)(ulong)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(ulong?))
            {
                return (decimal?)(ulong?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(decimal))
            {
                return (decimal)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(decimal?))
            {
                return (decimal?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(float))
            {
                return (float)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(float?))
            {
                return (float?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(double))
            {
                return (double)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(double?))
            {
                return (double?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(bool))
            {
                return (bool)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(bool?))
            {
                return (bool?)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                return (DateTime)property.GetValue(model) == default;
            }
            else if (property.PropertyType == typeof(DateTime?))
            {
                return (DateTime?)property.GetValue(model) == default;
            }
            else
            {
                object value = property.GetValue(model);

                if (value == null)
                {
                    return true;
                }

                return string.IsNullOrWhiteSpace(value.ToString());
            }
        }
    }
}
