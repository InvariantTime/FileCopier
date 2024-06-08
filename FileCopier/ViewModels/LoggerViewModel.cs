using FileCopier.Models;

namespace FileCopier.ViewModels
{
    public class LoggerViewModel : ViewModelBase
    {
        public string? Message { get; private set; }

        public StatusCodes Status { get; private set; }

        public int Progress { get; set; }

        public void ChangeStatus(string? message, StatusCodes code)
        {
            ChangeStatus(message, code, 0);
        }

        public void ChangeStatus(string? message, StatusCodes code, int progress)
        {
            Message = message;
            Status = code;
            Progress = progress;

            OnPropertyChanged(nameof(Message));
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(Progress));
        }
    }
}
