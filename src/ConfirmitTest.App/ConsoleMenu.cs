using ConfirmitTest.Core;
using ConfirmitTest.Core.Exceptions;

namespace ConfirmitTest.App
{
    public class ConsoleMenu
    {
        private readonly IDefaultConsoleCommand _defaultConsoleCommand;

        public ConsoleMenu(IDefaultConsoleCommand defaultConsoleCommand)
        {
            _defaultConsoleCommand = defaultConsoleCommand;
        }

        public void Start()
        {
            try
            {
                _defaultConsoleCommand.Execute();
            }
            catch (MenuExitException)
            {
            }
        }
    }
}