using System.Collections.Generic;
using System.Linq;
using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class DefaultConsoleCommand : IDefaultConsoleCommand
    {
        private readonly IConsoleCommand[] _consoleCommands;
        private readonly IOutputReciever _outputReciever;
        private readonly IOutputListManager<IConsoleCommand> _listManager;

        public DefaultConsoleCommand(
            IOutputReciever outputReciever, 
            IEnumerable<IConsoleCommand> consoleCommands,
            IOutputListManager<IConsoleCommand> listManager
        )
        {
            _outputReciever = outputReciever;
            _listManager = listManager;
            _consoleCommands = consoleCommands?.ToArray();
        }

        public string Title { get; } = "Main Menu";

        public void Execute()
        {
            // exit when throwed exception (MenuExitException)
            while (true)
            {
                _outputReciever.ClearScreen();
                WriteMenu();

                _outputReciever.Write("\nYour choise: ");

                var command = _listManager.GetSelectedItem();
                if (command.IsNull())
                {
                    _outputReciever.ClearScreen();
                    _outputReciever.WriteError(
                        "You've selected a nonexistent menu item! Try to select another one!"
                    );
                    continue;
                }

                command.Execute();
            }
        }

        private void WriteMenu()
        {
            _outputReciever.WriteLine($"{Title}\n");
            _listManager.SetItems(_consoleCommands);
            _listManager.SetItemToString(command => command.Title);
            _listManager.PrintItems();
        }
    }
}