
namespace FileCopier.Models
{
    public readonly struct FileCopyInfo
    {
        public string Source { get; init; }

        public string Path { get; init; }

        public FileCopyInfo(string source, string path)
        {
            Source = source;
            Path = path;
        }
    }
}
