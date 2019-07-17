using Abp.Application.Services;
using Emploee.Dto;
using Emploee.Logging.Dto;

namespace Emploee.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
