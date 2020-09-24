using System;
using System.IO;

namespace IsLeapYear.ConsoleApp.Tests.Helpers
{
    public sealed class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _textWriter;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _textWriter = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public void Dispose()
        {
            Console.SetOut(_textWriter);
            _stringWriter.Dispose();
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }
    }
}