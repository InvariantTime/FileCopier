using FileCopier.Commands;
using FileCopier.Commands.Interfaces;
using FileCopier.Models;
using FileCopier.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FileCopier.ViewModels
{
    public class FileCopierViewModel : ViewModelBase
    {
        private readonly IFileCopierService _copier;
        private readonly Lazy<IAsyncCommand<FileCopyInfo>> _copyCommand;

        public LoggerViewModel Logger { get; }

        public IAsyncCommand<FileCopyInfo> CopyCommand => _copyCommand.Value;

        public FileCopierViewModel(IFileCopierService copier)
        {
            _copier = copier;
            _copyCommand = new Lazy<IAsyncCommand<FileCopyInfo>>(() => new AsyncCommand<FileCopyInfo>(ExecuteCopyingAsync));

            Logger = new();
        }

        private async Task ExecuteCopyingAsync(FileCopyInfo info, CancellationToken token)
        {
            var progress = new Progress<FileCopyProgress>((info) =>
            {
                Logger.ChangeStatus($"progress {info.CurrentCount}/{info.Count}: {info.CurrentPath}", StatusCodes.Info, info.Percents);
            });

            var result = await _copier.CopyAsync(info, progress, token);

            if (result.IsSuccess == true)
            {
                Logger.ChangeStatus("Copying was successful", StatusCodes.Success);
            }
            else
            {
                Logger.ChangeStatus(result.Message, StatusCodes.Error);
            }
        }
    }
}