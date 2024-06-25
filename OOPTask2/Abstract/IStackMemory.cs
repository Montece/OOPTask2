namespace OOPTask2.Abstract;

internal interface IStackMemory
{
    bool HasElements { get; }
    public int ElementsCount { get; }

    void Push(double element);

    double? Pop();
}