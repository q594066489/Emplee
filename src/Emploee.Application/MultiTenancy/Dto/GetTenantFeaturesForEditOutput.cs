using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Emploee.Editions.Dto;

namespace Emploee.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}