using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using IsLeapYear.ConsoleApp.Tests.Helpers;
using Xunit;

namespace IsLeapYear.ConsoleApp.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(1900, false)]
        [InlineData(1990, false)]
        [InlineData(1992, true)]
        [InlineData(2000, true)]
        public void IsLeapYearTests(int year, bool expected)
        {
            // Arrange
            Assembly assembly = Assembly.LoadFrom("IsLeapYear.ConsoleApp.dll");
            object instance = assembly.CreateInstance("IsLeapYear.ConsoleApp.Program");
            Type type = instance.GetType();
            MethodInfo methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(x => x.Name.Equals("IsLeapYear") && x.IsPrivate)
                .First();

            // Act
            bool actual = (bool)methodInfo.Invoke(instance, new object[] { year });

            // Assert
            actual
                .Should()
                .Be(expected);
        }

        [Fact]
        public void MainTest()
        {
            // Arrange
            string expected = $"False{Environment.NewLine}False{Environment.NewLine}True{Environment.NewLine}True{Environment.NewLine}";
            Assembly assembly = Assembly.LoadFrom("IsLeapYear.ConsoleApp.dll");
            object instance = assembly.CreateInstance("IsLeapYear.ConsoleApp.Program");
            Type type = instance.GetType();
            MethodInfo methodInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(x => x.Name.Equals("Main") && x.IsPrivate)
                .First();

            // Act

            // Assert
            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                methodInfo.Invoke(instance, new object[] { Array.Empty<string>() });
                string actual = consoleOutput.GetOutput();

                actual
                    .Should()
                    .NotBeNullOrWhiteSpace()
                    .And
                    .Be(expected);
            }
        }
    }
}
