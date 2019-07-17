using System.Threading.Tasks;
using Emploee.Sessions.Dto;

namespace Emploee.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
