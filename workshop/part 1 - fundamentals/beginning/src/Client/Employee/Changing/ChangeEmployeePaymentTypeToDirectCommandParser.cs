using System;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeePaymentTypeToDirectCommandParser
    {
        private const string DirectPaymentType = "direct";
        
        public static ChangeEmployeePaymentTypeToDirectCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);

                Validate(arguments);
                
                return new ChangeEmployeePaymentTypeToDirectCommand(
                    GetIdFrom(arguments),
                    GetBankFrom(arguments),
                    GetAccountFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeePaymentTypeToDirectCommandStructureException(ex);
            }
        }
        
        private static string[] GetArgumentsFor(string command)
        {
            using (var reader = new StringReader(command))
            using (var textFieldParser = new TextFieldParser(reader))
            {
                textFieldParser.Delimiters = new[] { " " };
                textFieldParser.HasFieldsEnclosedInQuotes = true;
                textFieldParser.TrimWhiteSpace = true;

                var fields = textFieldParser.ReadFields();

                return fields?.Skip(1).ToArray() ?? new string[0];
            }
        }
        
        private static void Validate(string[] arguments)
        {
            if (arguments.Length > 4)
                throw new ChangeEmployeePaymentTypeToDirectCommandStructureException();

            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, DirectPaymentType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeePaymentTypeToDirectCommandStructureException();
        }
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static string GetBankFrom(string[] arguments) => arguments[2];
        
        private static string GetAccountFrom(string[] arguments) => arguments[3];
    }
}