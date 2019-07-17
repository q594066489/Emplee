using Abp.Application.Services;
using Emploee.Tenants.Dashboard.Dto;

namespace Emploee.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
