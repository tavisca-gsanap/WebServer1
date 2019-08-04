namespace WebServer1
{
    public class FileSystemFactory
    {
        public IFileSystem GetFileSystem(string fileSystem)
        {
            switch (fileSystem.ToLower())
            {
                case "local":
                    return new LocalFileSystem();
                default:
                    throw new InvalidFileSystemException();
            }
        }
    }
}
