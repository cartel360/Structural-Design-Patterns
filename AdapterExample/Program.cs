using System;

namespace AdapterPatternExample
{
    // Target interface (expected by the client)
    public interface IXmlParser
    {
        void ParseXml(string xmlData);
    }

    // Adaptee class (existing functionality that works with JSON)
    public class JsonParser
    {
        public void ParseJson(string jsonData)
        {
            Console.WriteLine("Parsing JSON data: " + jsonData);
        }
    }

    // Adapter class (converts XML data to JSON format)
    public class JsonParserAdapter : IXmlParser
    {
        private readonly JsonParser _jsonParser;

        public JsonParserAdapter(JsonParser jsonParser)
        {
            _jsonParser = jsonParser;
        }

        public void ParseXml(string xmlData)
        {
            // Mock conversion from XML to JSON
            string jsonData = $"{{ 'data': '{xmlData}' }}";
            _jsonParser.ParseJson(jsonData);
        }
    }

    // Example client code using the adapter
    class Program
    {
        static void Main(string[] args)
        {
            // Client expects IXmlParser but is given a JsonParserAdapter
            IXmlParser xmlParser = new JsonParserAdapter(new JsonParser());

            // Parsing XML data through the adapter
            xmlParser.ParseXml("<xml>Legacy XML Data</xml>");  // Adapter converts XML to JSON and then parses JSON

            // Output:
            // Parsing JSON data: { 'data': '<xml>Legacy XML Data</xml>' }
        }
    }
}
