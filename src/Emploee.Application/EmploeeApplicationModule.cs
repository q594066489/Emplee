using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Emploee.Authorization;
using Emploee;
using Emploee.Authorization;

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
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

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
