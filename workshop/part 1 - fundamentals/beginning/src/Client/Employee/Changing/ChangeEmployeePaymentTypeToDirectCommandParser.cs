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

                if (!AreValid(arguments))
                    throw new ChangeEmployeePaymentTypeToDirectCommandStructureException();
                
                return new ChangeEmployeePaymentTypeToDirectCommand(
                    GetIdFrom(arguments),
                    GetBankFrom(arguments),
                    GetAccountFrom(arguments));
            }
            catch (ChangeEmployeePaymentTypeToDirectCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeePaymentTypeToDirectCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 4 &&
            ChangeTypeIsDirectPaymentType(arguments);

        private static bool ChangeTypeIsDirectPaymentType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), DirectPaymentType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);

        private static string GetBankFrom(string[] arguments) => arguments[2];
        
        private static string GetAccountFrom(string[] arguments) => arguments[3];
    }
}