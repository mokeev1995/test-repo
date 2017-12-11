using System;
using System.Collections.Generic;
using System.Linq;
using ConfirmitTest.Core;

namespace ConfirmitTest.App
{
    public class ConsoleReciever : IOutputReciever
    {
        private enum MessageType
        {
            Info, Error, Warn
        }

        private (MessageType Type, string Text)? CurrentMessageInfo { get; set; }
        
        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Write(string format)
        {
            Console.Write(format);
        }

        public void WriteLine(string format)
        {
            Console.WriteLine(format);
        }

        public void WriteMenuItems(IEnumerable<string> items)
        {
            RestoreMessage();

            var currentItems = items.ToArray();

            for (var i = 0; i < currentItems.Length; i++)
                Console.WriteLine($"{i}. {currentItems[i]}");
        }

        public int GetIntResponse()
        {
            var resStr = Console.ReadLine();
            if (int.TryParse(resStr ?? "-1", out var res))
                return res;

            return -1;
        }

        public string GetStringResponse()
        {
            return Console.ReadLine();
        }

        public void WriteError(string message)
        {
            CurrentMessageInfo = (MessageType.Error, message);
            WriteMessage(message, ConsoleColor.DarkRed);
        }

        public void WriteInfo(string message)
        {
            CurrentMessageInfo = (MessageType.Info, message);
            WriteMessage(message, ConsoleColor.Blue);
        }

        public void WriteWarn(string message)
        {
            CurrentMessageInfo = (MessageType.Warn, message);
            WriteMessage(message, ConsoleColor.DarkYellow);
        }

        public void ClearScreen()
        {
            Console.Clear();
            
            RestoreMessage();
        }

        private void RestoreMessage()
        {
            if (CurrentMessageInfo == null)
                return;

            switch (CurrentMessageInfo?.Type)
            {
                case MessageType.Info:
                    WriteInfo(CurrentMessageInfo?.Text);
                    break;
                case MessageType.Error:
                    WriteError(CurrentMessageInfo?.Text);
                    break;
                case MessageType.Warn:
                    WriteWarn(CurrentMessageInfo?.Text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            CurrentMessageInfo = null;
        }

        private void WriteMessage(string message, ConsoleColor color)
        {
            var topPos = Console.CursorTop;
            var leftPos = Console.CursorLeft;

            var currentColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(0, Console.WindowHeight - 4);
            Console.Write(new string('_', Console.WindowWidth));
            Console.SetCursorPosition(1, Console.WindowHeight - 2);
            Console.Write($"(!) {message}");

            Console.ForegroundColor = currentColor;
            Console.SetCursorPosition(topPos, leftPos);
        }
    }
}