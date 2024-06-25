using OOPTask2.Abstract;

namespace OOPTask2;

public sealed class StackMemory : IStackMemory
{
    public bool HasElements => _stack.Count > 0;
    public int ElementsCount => _stack.Count;

    private readonly Stack<double> _stack = new();

    public void Push(double element)
    {
        _stack.Push(element);
    }

    public double? Pop()
    {
        if (!HasElements)
        {
            throw new InvalidOperationException("Нет элементов в памяти!");
        }

        var element = _stack.Pop();

        return element;
    }
}