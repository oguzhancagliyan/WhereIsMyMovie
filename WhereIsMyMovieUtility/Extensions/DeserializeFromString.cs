using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace WhereIsMyMovieUtility.Extensions
{
    public static class DeserializeFromString
    {

        public enum ContentType
        {
            Json,
            Xml
        }
        public static T GetDocumentFromString<T>(this string value, ContentType type) where T : class, new()
        {
            if (string.IsNullOrEmpty(value))
                return new T();
            else
            {
                switch (type)
                {
                    case ContentType.Json:
                        return GetJsonDeserialize<T>(value);
                    case ContentType.Xml:
                        return GetXmlDeserialize<T>(value);
                    default:
                        return new T();
                }
            }
        }
        private static T GetJsonDeserialize<T>(string content) where T : class, new()
        {
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
        private static T GetXmlDeserialize<T>(string content) where T : class, new()
        {
            var serializer = new XmlSerializer(typeof(T));
            var result = (T)serializer.Deserialize(new StreamReader(content));
            return result;
        }
    }
}
