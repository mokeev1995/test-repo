using System.Collections.Generic;
using System.Linq;
using ConfirmitTest.Core;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class DefaultConsoleCommand : IDefaultConsoleCommand
    {
        private readonly IConsoleCommand[] _consoleCommands;
        private readonly IOutputReciever _outputReciever;

        public DefaultConsoleCommand(IOutputReciever outputReciever, IEnumerable<IConsoleCommand> consoleCommands)
        {
            _outputReciever = outputReciever;
            _consoleCommands = consoleCommands?.ToArray();
        }

        public string Title { get; } = "Main Menu";

        public void Execute()
        {
            while (true)
            {
                RefreshScreen();
                WriteMenu();
                var input = GetInput();
                var command = GetCommand(input);
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

        private ICommand GetCommand(int input)
        {
            if (input < 0 || input > _consoleCommands.Length - 1)
                return null;
            return _consoleCommands[input];
        }

        private int GetInput()
        {
            return _outputReciever.GetIntResponse();
        }

        private void WriteMenu()
        {
            _outputReciever.WriteLine(Title);
            var titles = _consoleCommands.Select(command => command.Title);
            _outputReciever.WriteMenuItems(titles);
        }
    }
}