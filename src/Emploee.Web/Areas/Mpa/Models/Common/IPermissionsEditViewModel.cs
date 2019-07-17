using System.Collections.Generic;
using Emploee.Authorization.Permissions.Dto;

namespace Emploee.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}