namespace ConfirmitTest.Core
{
    public interface IConsoleCommand : ICommand
    {
        string Title { get; }
    }
}