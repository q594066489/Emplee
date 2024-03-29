﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Emploee.Authorization.Permissions.Dto;

namespace Emploee.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}