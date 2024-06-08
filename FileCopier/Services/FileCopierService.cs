using FileCopier.Models;
using FileCopier.Services.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileCopier.Services
{
    public class FileCopierService : IFileCopierService
    {
        private const int bufferSize = 1024 * 1024;

        public async Task<Result> CopyAsync(FileCopyInfo info, IProgress<FileCopyProgress> progress, CancellationToken token)
        {
            if (Directory.Exists(info.Source) == false)
                return Result.Failure($"Path \"{info.Source}\" is not exist");

            if (Directory.Exists(info.Path) == false)
                return Result.Failure($"Path \"{info.Path}\" is not exist");

            try
            {
                var files = Directory.GetFiles(info.Source);

                for (int i = 0; i < files.Length; i++)
                {
                    var name = Path.Combine(info.Path, Path.GetFileName(files[i]));

                    var progressData = new FileCopyProgress(files.Length, files[i], i + 1, 0);

                    progress.Report(progressData);
                    await CopyFileAsync(new FileCopyInfo(files[i], name), progress, progressData, token);

                    if (token.IsCancellationRequested == true)
                        return Result.Failure("Copying was canceled");
                }
            }
            catch (Exception e)
            {
                return Result.Failure(e.Message);
            }

            return Result.Success();
        }

        private static async Task CopyFileAsync(FileCopyInfo info, IProgress<FileCopyProgress> progress,
            FileCopyProgress progressData, CancellationToken token)
        {
            using var sourceStream = File.OpenRead(info.Source);
            using var pathStream = File.OpenWrite(info.Path);

            byte[] buffer = new byte[bufferSize];
            int byteCount = 0;

            while ((byteCount = await sourceStream.ReadAsync(buffer, token)) > 0)
            {
                if (token.IsCancellationRequested == true)
                    return;

                await pathStream.WriteAsync(buffer, token);

                progressData.Percents = GetPercents(pathStream.Position, sourceStream.Length);
                progress.Report(progressData);
            }
        }


        private static int GetPercents(long current, long max)
        {
            return (int)Math.Min((current * 100 / max), 100);
        }
    }
}