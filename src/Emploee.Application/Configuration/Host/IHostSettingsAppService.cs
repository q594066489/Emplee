using System.Threading.Tasks;
using Abp.Application.Services;
using Emploee.Configuration.Host.Dto;

namespace Emploee.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
