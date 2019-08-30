using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Emploee.Authorization;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Emploee.JobPosts.Authorization;
using Emploee.Emploee.JobUrgents.Authorization;
using Emploee.Emploee.PersonInfos.Authorization;
using Emploee.Approvals.Authorization;
using Emploee.Emploee.Advertisements.Authorization;
using Emploee.Emploee.Dictionaries.Authorization;
using Emploee.Emploee.Job_Positions.Authorization;
 

namespace Emploee
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(typeof(EmploeeCoreModule))]
    public class EmploeeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            //Configuration.Authorization.Providers.Add<adminAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CompanyAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<JobUrgentAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<PersonInfoAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<ApprovalAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<AdvertisementAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<DictionaryAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<JobPostAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<JobPositionAppAuthorizationProvider>();
            //Adding custom AutoMapper mappings
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
