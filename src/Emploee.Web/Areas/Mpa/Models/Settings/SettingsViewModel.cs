﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Emploee.Configuration.Tenants.Dto;

namespace Emploee.Web.Areas.Mpa.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}