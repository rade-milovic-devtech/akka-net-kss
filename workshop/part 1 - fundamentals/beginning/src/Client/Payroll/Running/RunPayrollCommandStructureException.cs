using System;

namespace AkkaPayroll.Client.Payroll.Running
{
    public class RunPayrollCommandStructureException : Exception
    {
        private const string ErrorMessage = "Inappropriate command structure. The required format is: \"Payday <date>\".";

        public RunPayrollCommandStructureException() : base(ErrorMessage) {}

        public RunPayrollCommandStructureException(Exception innerException) : base(ErrorMessage, innerException) {}
    }
}