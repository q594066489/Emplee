using System;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.TestBase;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Emploee;
using NSubstitute;

namespace Emploee.Tests
{
    [DependsOn(
        typeof(EmploeeApplicationModule),
        typeof(EmploeeDataModule),
        typeof(AbpTestBaseModule),
        typeof(AbpZeroCommonModule))]
    public class EmploeeTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<IAbpZeroDbMigrator>();
        }

        private void RegisterFakeService<TService>() 
            where TService : class
        {
            var instance = Substitute.For<TService>();
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .Instance(instance)
                    .LifestyleSingleton()
            );
        }
    }
}
