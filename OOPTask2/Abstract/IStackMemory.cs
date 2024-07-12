namespace OOPTask2.Abstract;

public interface IStackMemory
{
    bool HasElements { get; }
    public int ElementsCount { get; }

    void Push(double element);

    double Pop();

    IReadOnlyCollection<double> GetMemoryState();
}