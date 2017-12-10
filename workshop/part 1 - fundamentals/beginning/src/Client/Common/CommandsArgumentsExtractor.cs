using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace AkkaPayroll.Client.Common
{
    public static class CommandsArgumentsExtractor
    {
        public static string[] ExtractFrom(string command)
        {
            using (var reader = new StringReader(command))
            using (var textFieldParser = new TextFieldParser(reader))
            {
                textFieldParser.Delimiters = new[] { " " };
                textFieldParser.HasFieldsEnclosedInQuotes = true;
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.TrimWhiteSpace = true;

                var fields = textFieldParser.ReadFields();

                return fields?.Skip(1).ToArray() ?? new string[0];
            }
        }
    }
}