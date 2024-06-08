using FileCopier.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileCopier.Services.Interfaces
{
    public interface IFileCopierService
    {
        Task<Result> CopyAsync(FileCopyInfo info, IProgress<FileCopyProgress> progress, CancellationToken token);
    }
}