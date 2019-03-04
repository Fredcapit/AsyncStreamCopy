using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


namespace AsyncStream
{
    public partial class AsyncStreamCopy
    {

     public void Copy()
        {

            token = cancelTokenSource.Token;
            Task reading = new Task(ReadFromSrc);
            reading.Start();
            WriteToDest();

        }

        

    }

}
