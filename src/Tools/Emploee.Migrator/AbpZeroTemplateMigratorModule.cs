using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Emploee.EntityFramework;

namespace Emploee.Migrator
{
    [DependsOn(typeof(EmploeeDataModule))]
    public class EmploeeMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<EmploeeDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}