namespace DotnetCoreWorker.Repositories
{
    public interface ICountRepository
    {
        int Count { get; }
        ICountRepository Increment(int step);
        ICountRepository Decrement(int step);
        ICountRepository Reset();
    }
}
