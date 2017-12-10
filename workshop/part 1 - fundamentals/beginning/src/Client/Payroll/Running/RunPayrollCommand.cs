using System;

namespace AkkaPayroll.Client.Payroll.Running
{
    public class RunPayrollCommand
    {
        public RunPayrollCommand(DateTime date)
        {
            Date = date;
        }
        
        public DateTime Date { get; }
        
        public override bool Equals(object obj)
        {
            var runPayrollCommand = obj as RunPayrollCommand;

            if (ReferenceEquals(runPayrollCommand, null)) return false;

            return Date == runPayrollCommand.Date;
        }

        public override int GetHashCode() => Date.GetHashCode();

        public override string ToString() => $"{nameof(RunPayrollCommand)} {{ {nameof(Date)}: {Date} }}";
    }
}