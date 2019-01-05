namespace DotnetCoreWorker.Repositories
{
    using System.Threading;

    public class CountRepository : ICountRepository
    {
        private int _count = 0;
        public int Count => _count;

        public ICountRepository Decrement(int step = 1)
        {
            Interlocked.Add(ref _count, -step);
            return this;
        }

        public ICountRepository Increment(int step = 1)
        {
            Interlocked.Add(ref _count, step);
            return this;
        }

        public ICountRepository Reset()
        {
            Interlocked.Exchange(ref _count, 0);
            return this;
        }
    }
}
