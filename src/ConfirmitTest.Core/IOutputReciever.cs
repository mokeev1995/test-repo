using System.Collections.Generic;

namespace ConfirmitTest.Core
{
    public interface IOutputReciever
    {
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
        void Write(string format);
        void WriteLine(string format);
        string GetStringResponse();
        int? GetIntResponse();
        void WriteError(string message);
        void WriteInfo(string message);
        void WriteWarn(string message);
        void ClearScreen();
    }
}