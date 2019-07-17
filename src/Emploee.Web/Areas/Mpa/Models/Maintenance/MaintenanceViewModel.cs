using System.Collections.Generic;
using Emploee.Caching.Dto;

namespace Emploee.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}