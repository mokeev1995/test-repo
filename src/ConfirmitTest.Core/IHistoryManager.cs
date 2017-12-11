namespace ConfirmitTest.Core
{
    public interface IHistoryManager<T>
        where T : class
    {
        void SaveNextState(T item);
        T GetCurrentItem();
        T Undo(uint countToRollback);
        T Redo(uint countToDo);
    }
}