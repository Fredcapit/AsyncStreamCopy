using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace AsyncStream
{
    public partial class AsyncStreamCopy
    {
        private void ReadFromSrc()
        {
            byte[] _readbuffer = new byte[_buffersize];
            int _readbytes = 0;
            
            do
            {
                //Читаем блок данных
                _readbytes = src_stream.Read(_readbuffer, 0, _buffersize);
           
                lock (locker)
                {
                    sourceIsReading = _readbytes > 0;
                    if (sourceIsReading)
                    {

                        //Копируем в новый массив байт с размером фактически прочитанных байт
                        byte[] __readbuffer = new byte[_readbytes];
                        Buffer.BlockCopy(_readbuffer, 0, __readbuffer, 0, _readbytes);
                        //Добавляем массив байт с фактическим размеров в очередь

                        bufferQueue.Enqueue(__readbuffer);
                    }
                }


            }
            //Продолжаем действия пока поток читается
            while (sourceIsReading && !token.IsCancellationRequested );
            

        }
        private void WriteToDest()
        {
            byte[] __writebuffer = new byte[_buffersize];
            int __writebufferlen = 0;

            do
            {
                lock (locker)
                {
                    bufferQueueIsEmpty = bufferQueue.Count == 0;
                    if (!bufferQueueIsEmpty)
                    {
                        __writebufferlen = bufferQueue.Peek().Length;
                        if (__writebufferlen > 0)
                        {
                            byte [] __writebufferitem = bufferQueue.Dequeue();
                            Buffer.BlockCopy(__writebufferitem, 0, __writebuffer, 0, __writebufferlen);

                        }

                    }
                }
                try
                {
                    if (__writebufferlen>0)
                        dts_stream.Write(__writebuffer, 0, __writebufferlen);
                }
                catch (Exception e)
                {
                    Exception b = e.GetBaseException();
                    Debug.WriteLine(b.Message);
                    sourceIsReading = false;
                    bufferQueueIsEmpty = true;
                    cancelTokenSource.Cancel();
                }
            }
            while (sourceIsReading || !bufferQueueIsEmpty);
           
        }
    }
}
