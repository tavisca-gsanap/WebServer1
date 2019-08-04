using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServer1
{
    public interface IFileSystem
    {
        string ResolveVirtualPath(string rootDirectory, string virtualPath);
        bool TryGetFile(string physicalPath, out FileInfo fileInfo);
    }
}
