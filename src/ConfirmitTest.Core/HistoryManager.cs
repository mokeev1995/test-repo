using System.Collections.Generic;

namespace ConfirmitTest.Core
{
    public class HistoryManager<T> : IHistoryManager<T>
        where T : class
    {
        private readonly List<T> _data;
        private int _currentIndex;

        public HistoryManager()
        {
            _data = new List<T>();
            _currentIndex = -1;
        }

        public void SaveNextState(T item)
        {
            if (_currentIndex <= _data.Count)
            {
                _data.Add(item);
            }
            else
            {
                _data[_currentIndex] = item;
                ClearAfter(_currentIndex);
            }

            _currentIndex++;
        }

        public T GetCurrentItem()
        {
            return _data[_currentIndex];
        }

        public T Undo(uint countToRollback)
        {
            var rollbackTo = _currentIndex - countToRollback;
            _currentIndex = rollbackTo >= 0 ? (int) rollbackTo : 0;

            return GetCurrentItem();
        }

        public T Redo(uint countToDo)
        {
            if (_currentIndex == _data.Count - 1)
                return GetCurrentItem();

            var redoTo = _currentIndex + countToDo;
            _currentIndex = redoTo > _data.Count - 1 ? _data.Count - 1 : (int) redoTo;

            return GetCurrentItem();
        }

        private void ClearAfter(int currentIndex)
        {
            currentIndex++;
            _data.RemoveRange(currentIndex, _data.Count - currentIndex);
        }
    }
}