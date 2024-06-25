using Xunit;

namespace OOPTask2.Tests
{
    public sealed class StackMemoryTests
    {
        [Fact]
        public void StackMemory_HasElements()
        {
            var memory = new StackMemory();
            var hasElementsBeforeAdding = memory.HasElements;
            memory.Push(1);
            var hasElementsAfterAdding = memory.HasElements;

            Assert.True(!hasElementsBeforeAdding && hasElementsAfterAdding);
        }

        [Fact]
        public void StackMemory_ElementsCount()
        {
            var memory = new StackMemory();
            var elementsCountBeforeAdding = memory.ElementsCount;
            memory.Push(1);
            var elementsCountAfterAdding = memory.ElementsCount;

            Assert.True(elementsCountBeforeAdding == 0 && elementsCountAfterAdding == 1);
        }

        [Fact]
        public void StackMemory_Push()
        {
            var memory = new StackMemory();
            memory.Push(1d);
            memory.Push(2d);
            memory.Push(3d);

            var elementsCountAfterAdding = memory.ElementsCount;

            Assert.Equal(3, elementsCountAfterAdding);
        }

        [Fact]
        public void StackMemory_Pop()
        {
            var memory = new StackMemory();

            memory.Push(1d);
            memory.Push(2d);

            var firstElement = memory.Pop();
            var secondElement = memory.Pop();

            Assert.True(firstElement.Equals(2d) && secondElement.Equals(1d));
        }
    }
}
