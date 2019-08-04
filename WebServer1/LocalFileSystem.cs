using System.IO;

namespace WebServer1
{
    public class LocalFileSystem : IFileSystem
    {
        public string ResolveVirtualPath(string rootDirectory, string virtualPath)
        {
            return rootDirectory + virtualPath;
        }

        public bool TryGetFile(string physicalPath, out FileInfo fileInfo)
        {
            fileInfo = new FileInfo(physicalPath);
            return fileInfo.Exists;
        }

        //public byte[] GetFileStream(FileInfo fileInfo)
        //{
        //    fileInfo = new FileInfo(physicalPath);
        //    if (fileInfo.Exists)
        //    {

        //    }
        //    FileStream fileStream = fileInfo.OpenRead();
        //    byte[] buffer = new byte[fileStream.Length];
        //    fileStream.Read(buffer, 0, buffer.Length);
        //    return buffer;
        //}
    }
}
