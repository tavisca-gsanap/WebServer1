using System;
using Xunit;
using WebServer1;
using System.IO;

namespace WebServer1Test
{
    public class UnitTest1
    {
        LocalFileSystem _localFileSystem = new LocalFileSystem();
        [Fact]
        public void FileExistsTest()
        {
            string physicalPath = _localFileSystem.ResolveVirtualPath(@"C:\Users\gsanap\Desktop\", "index.html");
            //@ can be used to avoid using \\ .
            FileInfo fileInfo;
            bool exists = _localFileSystem.TryGetFile(physicalPath,out fileInfo);
            //var buffer = FileReader.GetFileStream(fileInfo);
            Assert.True(exists);
        }
    }
}
