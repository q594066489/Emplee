using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Authorization.Permissions.Dto;

namespace Emploee.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
