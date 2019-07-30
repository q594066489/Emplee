using System.Linq;
using Abp;
using Abp.Authorization;
using Emploee.Authorization;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Tenants.Dashboard.Dto;

namespace Emploee.Tenants.Dashboard
{
    [AbpAuthorize(CompanyAppPermissions.Company)]
    public class TenantDashboardAppService : EmploeeAppServiceBase, ITenantDashboardAppService
    {
        public GetMemberActivityOutput GetMemberActivity()
        {
            //Generating some random data. We could get numbers from database...
            return new GetMemberActivityOutput
                   {
                       TotalMembers = Enumerable.Range(0, 13).Select(i => RandomHelper.GetRandom(15, 40)).ToList(),
                       NewMembers = Enumerable.Range(0, 13).Select(i => RandomHelper.GetRandom(3, 15)).ToList()
                   };
        }
    }
}