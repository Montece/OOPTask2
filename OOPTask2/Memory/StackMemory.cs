namespace OOPTask2.Memory;

public sealed class StackMemory : IStackMemory
{
    public bool HasElements => _stack.Count > 0;
    public int ElementsCount => _stack.Count;

    private readonly Stack<double> _stack = new();

    public void Push(double element)
    {
        _stack.Push(element);
    }

    public double Pop()
    {
        if (!HasElements)
        {
            throw new EmptyMemoryException();
        }

        var element = _stack.Pop();

        return element;
    }

    public IReadOnlyCollection<double> GetMemoryState() => _stack.ToArray();
}