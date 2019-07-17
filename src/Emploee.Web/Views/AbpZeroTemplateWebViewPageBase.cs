using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;

namespace Emploee.Web.Views
{
    public abstract class EmploeeWebViewPageBase : EmploeeWebViewPageBase<dynamic>
    {
       
    }

    public abstract class EmploeeWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected EmploeeWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = EmploeeConsts.LocalizationSourceName;
        }
    }
}