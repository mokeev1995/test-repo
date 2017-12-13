using System;
using ConfirmitTest.Core;
using Xunit;

namespace ConfirmitTest.Tests.Core
{
    public class HistoryManagerTests
    {
        private IHistoryManager<T> GetHistoryManager<T>() 
            where T : class
        {
            return new HistoryManager<T>();
        }

        [Fact]
        public void HistoryWrites()
        {
            var hm = GetHistoryManager<string>();

            const string state = "start-state";

            hm.SaveNextState(state);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectly()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState("start-state");
            hm.SaveNextState("start-state-1");
            hm.SaveNextState("start-state-2");
            hm.SaveNextState(state);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectlyAfterUndo()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState("start-state");
            hm.SaveNextState("start-state-1");
            hm.SaveNextState("start-state-2");
            hm.SaveNextState("start-state-3");
            hm.SaveNextState("start-state-4");
            hm.Undo(4);
            hm.SaveNextState(state);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectlyAfterUndo_WithBigCount()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState(state);
            hm.SaveNextState("undo-state-1");
            hm.SaveNextState("undo-state-2");
            hm.SaveNextState("undo-state-3");
            hm.SaveNextState("undo-state-4");
            hm.Undo(int.MaxValue);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectlyAfterUndoAndRedo()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState("start-state");
            hm.SaveNextState(state);
            hm.SaveNextState("start-state-2");
            hm.SaveNextState("start-state-3");
            hm.SaveNextState("start-state-4");
            hm.Undo(4);
            hm.Redo(1);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectlyAfterUndoAndRedo_WithBigCount()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState("start-state");
            hm.SaveNextState("start-state-1");
            hm.SaveNextState("start-state-2");
            hm.SaveNextState("start-state-3");
            hm.SaveNextState("start-state-4");
            hm.SaveNextState(state);
            hm.Undo(4);
            hm.Redo(int.MaxValue);

            Assert.Equal(state, hm.GetCurrentItem());
        }

        [Fact]
        public void HistoryWritesCorrectlyAfterRedo_WithoutUndo()
        {
            var hm = GetHistoryManager<string>();

            const string state = "end-state";

            hm.SaveNextState("start-state");
            hm.SaveNextState(state);
            hm.Redo(1);

            Assert.Equal(state, hm.GetCurrentItem());
        }
    }
}