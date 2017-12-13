using System.Linq;
using ConfirmitTest.Core;
using ConfirmitTest.Tests.SharedClasses;
using Xunit;

namespace ConfirmitTest.Tests.Core
{
    internal class TestClassWithToString
    {
        private readonly string _something;

        public TestClassWithToString(string something)
        {
            _something = something;
        }

        public override string ToString()
        {
            return _something;
        }
    }

    public class OutputListManagerTests
    {
        [Fact]
        public void JustPrintItems()
        {
            var output = new TestOutputReciever();
            var listManager = GetListManager<string>(output);

            var items = new[]
            {
                "test1",
                "test2"
            };

            listManager.SetItems(items);
            listManager.PrintItems();

            var result = items.Select((s, i) => $"{i}. {s}");
            Assert.Equal(result, output.WriteLines);
        }

        [Fact]
        public void JustPrintItems_WithExternalClass()
        {
            var output = new TestOutputReciever();
            var listManager = GetListManager<TestClassWithToString>(output);

            var items = new[]
            {
                new TestClassWithToString("test1"), 
                new TestClassWithToString("test2"), 
            };

            listManager.SetItems(items);
            listManager.PrintItems();

            var result = items.Select((s, i) => $"{i}. {s}");
            Assert.Equal(result, output.WriteLines);
        }

        [Fact]
        public void JustPrintItems_WithExternalClass_WithCustomToString()
        {
            var output = new TestOutputReciever();
            var listManager = GetListManager<TestClassWithToString>(output);

            var items = new[]
            {
                new TestClassWithToString("test1"), 
                new TestClassWithToString("test2"), 
            };

            listManager.SetItemToString(s => $"{s} -- custom");

            listManager.SetItems(items);
            listManager.PrintItems();

            var result = items.Select((s, i) => $"{i}. {s} -- custom");
            Assert.Equal(result, output.WriteLines);
        }

        private IOutputListManager<T> GetListManager<T>(IOutputReciever outputReciever)
            where T : class
        {
            return new OutputListManager<T>(outputReciever);
        }
    }
}