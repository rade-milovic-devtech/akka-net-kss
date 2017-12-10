using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeePaymentTypeToDirectCommandParser
    {
        private const string DirectPaymentType = "direct";
        
        public static ChangeEmployeePaymentTypeToDirectCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

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