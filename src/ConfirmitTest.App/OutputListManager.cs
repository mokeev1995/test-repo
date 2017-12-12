using System;
using System.Collections.Generic;
using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;

namespace ConfirmitTest.App
{
    public interface IOutputListManager<T> 
        where T : class
    {
        void SetItems(IEnumerable<T> items);
        void SetItemToString(Func<T, string> toStringFunc);
        void PrintItems();
        T GetSelectedItem();
    }

    public class OutputListManager<T> : IOutputListManager<T> 
        where T: class
    {
        private readonly IOutputReciever _outputReciever;
        private readonly List<T> _items;
        private Func<T, string> _toStringFunc;

        public OutputListManager(IOutputReciever outputReciever)
        {
            _outputReciever = outputReciever;
            _items = new List<T>();
        }

        public void SetItems(IEnumerable<T> items)
        {
            _items.Clear();
            _items.AddRange(items);
        }

        public void SetItemToString(Func<T, string> toStringFunc)
        {
            _toStringFunc = toStringFunc;
        }

        public void PrintItems()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                var itemString = _toStringFunc.IsNull()
                    ? _items[i].ToString()
                    : _toStringFunc(_items[i]);
                
                _outputReciever.WriteLine($"{i}. {itemString}");
            }
        }

        public T GetSelectedItem()
        {
            var prod = _outputReciever.GetIntResponse() ?? -1;

            if (prod >= 0 && prod <= _items.Count - 1)
                return _items[prod];

            return null;
        }
    }
}