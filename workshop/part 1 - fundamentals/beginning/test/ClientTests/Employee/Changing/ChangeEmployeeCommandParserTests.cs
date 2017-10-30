using FluentAssertions;
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AkkaPayroll.Client.Tests.Employee.Changing
{
    public class ChangeEmployeeCommandParserTests
    {
        [Theory, AutoData]
        public void ShouldRecognizeChangeEmployeeNameCommand(int id, string name)
        {
            var expectedChangeEmployeeNameCommand = new ChangeEmployeeNameCommand(id, name);
            var command = $"ChgEmp {id} Name \"{name}\"";

            var changeEmployeeNameCommand = ChangeEmployeeNameCommandParser.Parse(command);

            changeEmployeeNameCommand.Should().Be(expectedChangeEmployeeNameCommand);
        }
    }

    public static class ChangeEmployeeNameCommandParser
    {
        public static ChangeEmployeeNameCommand Parse(string command)
        {
            var arguments = GetArgumentsFor(command);

            return new ChangeEmployeeNameCommand(int.Parse(arguments[0]), arguments[2]);
        }

        private static string[] GetArgumentsFor(string command)
        {
            var commandTokens = command.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(token => !string.IsNullOrWhiteSpace(token))
                .ToArray();

            var arguments = new List<string>();
            arguments.AddRange(commandTokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1));
            arguments.Add(commandTokens[1]);

            return arguments.ToArray();
        }
    }

    public class ChangeEmployeeNameCommand
    {
        public int Id { get; }
        public string Name { get; }

        public ChangeEmployeeNameCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            var changeEmployeeNameCommand = obj as ChangeEmployeeNameCommand;

            if (ReferenceEquals(changeEmployeeNameCommand, null))
                return false;

            return Id == changeEmployeeNameCommand.Id && Name == changeEmployeeNameCommand.Name;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ Name.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString() =>
            $"{nameof(ChangeEmployeeNameCommand)} {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name} }}";
    }
}
