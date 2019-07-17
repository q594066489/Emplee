using System.Threading.Tasks;
using Abp.Application.Services;
using Emploee.Configuration.Tenants.Dto;

namespace Emploee.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
