using System;
using AkkaPayroll.Client.Common;

namespace AkkaPayroll.Client.Employee.Changing
{
    public static class ChangeEmployeeToNonUnionMemberCommandParser
    {
        private const string CutEmployeeFromUnionChangeType = "nomember";
        
        public static ChangeEmployeeToNonUnionMemberCommand Parse(string command)
        {
            try
            {
                var arguments = CommandsArgumentsExtractor.ExtractFrom(command);
            
                if (!AreValid(arguments))
                    throw new ChangeEmployeeToNonUnionMemberCommandStructureException();
            
                return new ChangeEmployeeToNonUnionMemberCommand(GetIdFrom(arguments));
            }
            catch (ChangeEmployeeToNonUnionMemberCommandStructureException) { throw; }
            catch (Exception ex)
            {
                throw new ChangeEmployeeToNonUnionMemberCommandStructureException(ex);
            }
        }
        
        private static bool AreValid(string[] arguments) =>
            arguments.Length == 2 &&
            ChangeTypeIsCutEmployeeFromUnion(arguments);

        private static bool ChangeTypeIsCutEmployeeFromUnion(string[] arguments) =>
            string.Equals(GetChangeTypeFrom(arguments), CutEmployeeFromUnionChangeType, StringComparison.InvariantCultureIgnoreCase);
        
        private static string GetChangeTypeFrom(string[] arguments) => arguments[1];
        
        private static int GetIdFrom(string[] arguments) => int.Parse(arguments[0]);
    }
}