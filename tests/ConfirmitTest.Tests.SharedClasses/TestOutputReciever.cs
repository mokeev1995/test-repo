using System.Collections.Generic;
using ConfirmitTest.Core;

namespace ConfirmitTest.Tests.SharedClasses
{
    public class TestOutputReciever : IOutputReciever
    {
        public TestOutputReciever()
            : this(new Queue<string>(), new Queue<string>(), new Queue<string>(), new Queue<string>(),
                new Queue<string>(), new Queue<string>(), new Queue<int?>())
        {
        }

        public TestOutputReciever(Queue<string> errorWrites, Queue<string> infoWrites, Queue<string> warnWrites,
            Queue<string> writes, Queue<string> writeLines, Queue<string> getStringResponses,
            Queue<int?> getIntResponses)
        {
            ErrorWrites = errorWrites;
            InfoWrites = infoWrites;
            WarnWrites = warnWrites;
            Writes = writes;
            WriteLines = writeLines;
            GetStringResponses = getStringResponses;
            GetIntResponses = getIntResponses;
        }

        public Queue<string> ErrorWrites { get; }
        public Queue<string> InfoWrites { get; }
        public Queue<string> WarnWrites { get; }
        public Queue<string> Writes { get; }
        public Queue<string> WriteLines { get; }
        public Queue<string> GetStringResponses { get; }
        public Queue<int?> GetIntResponses { get; }

        public void Write(string format, params object[] args)
        {
            Writes.Enqueue(string.Format(format, args));
        }

        public void WriteLine(string format, params object[] args)
        {
            WriteLines.Enqueue(string.Format(format, args));
        }

        public void Write(string format)
        {
            Writes.Enqueue(format);
        }

        public void WriteLine(string format)
        {
            WriteLines.Enqueue(format);
        }

        public string GetStringResponse()
        {
            return GetStringResponses.Dequeue();
        }

        public int? GetIntResponse()
        {
            return GetIntResponses.Dequeue();
        }

        public void WriteError(string message)
        {
            ErrorWrites.Enqueue(message);
        }

        public void WriteInfo(string message)
        {
            InfoWrites.Enqueue(message);
        }

        public void WriteWarn(string message)
        {
            WarnWrites.Enqueue(message);
        }

        public void ClearScreen()
        {
        }
    }
}