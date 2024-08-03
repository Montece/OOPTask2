namespace OOPTask2.Memory;

public interface IStackMemory
{
    bool HasElements { get; }
    public int ElementsCount { get; }

    void Push(double element);

    double Pop();

    IReadOnlyCollection<double> GetMemoryState();
}