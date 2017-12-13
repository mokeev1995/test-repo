using System;
using ConfirmitTest.Core;
using ConfirmitTest.Shop;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class UndoConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;

        public UndoConsoleCommand(
            IOutputReciever outputReciever,
            ICartService cartService
        )
        {
            _outputReciever = outputReciever;
            _cartService = cartService;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();

            _outputReciever.Write("How much commands do we need to rollback? [1] ");
            var count = _outputReciever.GetIntResponse() ?? 1;
            _cartService.Undo(Convert.ToUInt32(count));
            _outputReciever.WriteInfo($"Up to {count} command(-s) was successfully reverted.");
        }

        public string Title { get; } = "Rollback last N actions";
    }
}