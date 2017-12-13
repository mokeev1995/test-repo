using ConfirmitTest.Core;
using ConfirmitTest.Core.Exceptions;

namespace ConfirmitTest.Commands
{
    public class ExitConsoleCommand : IDefaultConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;

        public ExitConsoleCommand(IOutputReciever outputReciever)
        {
            _outputReciever = outputReciever;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            _outputReciever.WriteInfo("Bye!");
            throw new MenuExitException();
        }

        public string Title { get; } = "Exit";
    }
}