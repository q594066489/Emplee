using Abp.WebApi.Controllers;

namespace Emploee.WebApi
{
    public abstract class EmploeeApiControllerBase : AbpApiController
    {
        protected EmploeeApiControllerBase()
        {
            LocalizationSourceName = EmploeeConsts.LocalizationSourceName;
        }
    }
}