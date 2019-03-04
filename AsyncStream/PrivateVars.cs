using System.Collections.Generic;
using System.IO;


namespace AsyncStream
{
    public partial class AsyncStreamCopy
    {
        /// <summary>
        /// Поток данных от удаленного источника.
        /// </summary>
        private Stream src_stream;
        /// <summary>
        /// Целевой поток для записи
        /// </summary>
        private Stream dts_stream;
        /// <summary>
        /// Очередь массивов байт
        /// </summary>
        private Queue<byte[]> bufferQueue = new Queue<byte[]>();
        /// <summary>
        /// Объект блокировки для синхронизации потоков
        /// </summary>
        private object locker = new object();
        /// <summary>
        /// Размер буфера для чтения из потока-источника
        /// </summary>
        private readonly int _buffersize=1024*1024;
        /// <summary>
        /// Флаг - если true,то происходит чтение из источника
        /// </summary>
        private volatile bool sourceIsReading;
        /// <summary>
        /// Флаг - true означает что буфер-очередь пуст.
        /// </summary>
        private volatile bool bufferQueueIsEmpty;

        
    }
}
