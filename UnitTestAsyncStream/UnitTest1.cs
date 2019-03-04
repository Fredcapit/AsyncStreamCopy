using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncStream;
using System.IO;
namespace UnitTestAsyncStream
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stream source = File.OpenRead("D:\\VIDEO\\20170104_185141.MOV");
            Stream dest = File.Create("D:\\dest.MOV");
            new AsyncStreamCopy(source, dest).Copy();
   
            source.Close();
            dest.Close();
            Assert.AreEqual(1, 1);
        }
    }
}
