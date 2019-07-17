using System.Threading.Tasks;
using Abp.Configuration;

namespace Emploee.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
