using System;
using System.IO;
using System.Threading;

namespace AsyncStream
{
    public partial class AsyncStreamCopy
    {
        public AsyncStreamCopy(Stream source, Stream destination)
        {
            src_stream = source;
            dts_stream = destination;
            cancelTokenSource = new CancellationTokenSource();
            sourceIsReading = true;
        }
    }
}
