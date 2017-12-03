using System;
using System.Linq;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeePaymentTypeToHoldCommandParser
    {
        private const string HoldPaymentType = "hold";
        
        public static ChangeEmployeePaymentTypeToHoldCommand Parse(string command)
        {
            try
            {
                var arguments = GetArgumentsFor(command);
            
                Validate(arguments);
            
                return new ChangeEmployeePaymentTypeToHoldCommand(GetIdFrom(arguments));
            }
            catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
            {
                throw new ChangeEmployeePaymentTypeToHoldCommandStructureException(ex);
            }
        }
        
        private static string[] GetArgumentsFor(string command)
        {
            var commandTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);;

            return commandTokens.Where(token => !string.IsNullOrWhiteSpace(token))
                .Skip(1)
                .ToArray();
        }
        
        private static void Validate(string[] arguments)
        {
            if (arguments.Length > 2)
                throw new ChangeEmployeePaymentTypeToHoldCommandStructureException();
            
            var changeType = GetChangeTypeFrom(arguments);
            if (!string.Equals(changeType, HoldPaymentType, StringComparison.InvariantCultureIgnoreCase))
                throw new ChangeEmployeePaymentTypeToHoldCommandStructureException();
        }
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
    }
}