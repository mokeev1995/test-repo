using System.Collections.Generic;
using System.Linq;
using ConfirmitTest.Core;

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
            while (true)
            {
                RefreshScreen();
                WriteMenu();
                var command = GetCommand();
                if (command == null)
                {
                    RefreshScreen();
                    WriteWrongSelectionMessage();
                    continue;
                }
                command.Execute();
            }
        }

        private void WriteWrongSelectionMessage()
        {
            _outputReciever.WriteError("You've selected a nonexistent menu item! Try to select another one!");
        }

        private void RefreshScreen()
        {
            _outputReciever.ClearScreen();
        }

        private ICommand GetCommand()
        {
            return _listManager.GetSelectedItem();
        }

        private void WriteMenu()
        {
            _outputReciever.WriteLine(Title);
            _listManager.SetItems(_consoleCommands);
            _listManager.SetItemToString(command => command.Title);
            _listManager.PrintItems();
        }
    }
}