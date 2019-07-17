using System.Threading.Tasks;
using Abp.Application.Services;
using Emploee.Sessions.Dto;

namespace Emploee.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
