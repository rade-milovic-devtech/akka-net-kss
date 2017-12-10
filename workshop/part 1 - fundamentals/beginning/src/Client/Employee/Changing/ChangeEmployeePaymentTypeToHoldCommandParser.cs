using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeePaymentTypeToHoldCommandParser
    {
        private const string HoldPaymentType = "hold";
        
        public static ChangeEmployeePaymentTypeToHoldCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);

                if (!AreValid(arguments))
                    throw new ChangeEmployeePaymentTypeToHoldCommandStructureException();

                return new ChangeEmployeePaymentTypeToHoldCommand(GetIdFrom(arguments));
            }
            catch (ChangeEmployeePaymentTypeToHoldCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeePaymentTypeToHoldCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 2 &&
            ChangeTypeIsHoldPaymentType(arguments);

        private static bool ChangeTypeIsHoldPaymentType(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), HoldPaymentType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
    }
}