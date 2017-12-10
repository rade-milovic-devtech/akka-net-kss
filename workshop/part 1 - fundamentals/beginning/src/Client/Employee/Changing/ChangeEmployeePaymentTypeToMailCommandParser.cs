using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeePaymentTypeToMailCommandParser
    {
        private const string MailPaymentType = "mail";
        
        public static ChangeEmployeePaymentTypeToMailCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

                if (!AreValid(arguments))
                    throw new ChangeEmployeePaymentTypeToMailCommandStructureException();

                return new ChangeEmployeePaymentTypeToMailCommand(GetIdFrom(arguments), GetAddressFrom(arguments));
            }
            catch (ChangeEmployeePaymentTypeToMailCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeePaymentTypeToMailCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 3 &&
            ChangeTypeIsMailPaymentType(arguments);

        private static bool ChangeTypeIsMailPaymentType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), MailPaymentType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
        
        private static string GetAddressFrom(string[] arguments) => arguments[2];
    }
}