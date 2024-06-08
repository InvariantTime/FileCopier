
namespace FileCopier.Models
{
    public struct FileCopyProgress
    {
        public int Count { get; }

        public string? CurrentPath { get; set; }

        public int CurrentCount { get; set; }

        public int Percents { get; set; }

        public FileCopyProgress(int count, string currentPath, int currentCount, int percents)
        {
            Count = count;
            CurrentPath = currentPath;
            CurrentCount = currentCount;
            Percents = percents;
        }
    }
}