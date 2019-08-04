using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServer1
{
    public interface IFileSystem
    {
        bool TryGetFile(string physicalPath, out FileInfo fileInfo);
        byte[] ReadFile(FileInfo fileInfo);
    }
}
