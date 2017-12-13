using System;
using ConfirmitTest.Core;
using ConfirmitTest.Shop;

namespace ConfirmitTest.Commands
{
    public class RedoConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;

        public RedoConsoleCommand(
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
            _outputReciever.Write("How much commands do we need to do again? [1] ");
            var count = _outputReciever.GetIntResponse() ?? 1;
            _cartService.Redo(Convert.ToUInt32(count));
            _outputReciever.WriteInfo($"Up to {count} command(-s) was successfully redone.");
        }

        public string Title { get; } = "Revert rollback last N actions";
    }
}