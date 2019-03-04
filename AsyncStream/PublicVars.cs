using System.Threading;

namespace AsyncStream
{
    public partial class AsyncStream
    {
        public CancellationToken token;
        public CancellationTokenSource cancelTokenSource;
    }
}
