using Abp.Domain.Services;

namespace Emploee
{
    public abstract class EmploeeDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected EmploeeDomainServiceBase()
        {
            LocalizationSourceName = EmploeeConsts.LocalizationSourceName;
        }
    }
}
