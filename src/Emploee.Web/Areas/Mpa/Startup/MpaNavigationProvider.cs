using Abp.Application.Navigation;
using Abp.Localization;
using Emploee.Approvals.Authorization;
using Emploee.Authorization;
using Emploee.Emploee.JobPosts.Authorization;
using Emploee.Emploee.PersonInfos.Authorization;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Web.Navigation;

namespace Emploee.Web.Areas.Mpa.Startup
{
    public class MpaNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Mpa";
        
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));
            var company = new MenuItemDefinition(
                CompanyAppPermissions.Company,
                L("Company"),
                url: "Mpa/CompanyManage",
                icon: "icon-grid",
                                  requiredPermissionName: CompanyAppPermissions.Company
                                     );
              
            var jobPost = new MenuItemDefinition(
                JobPostAppPermissions.JobPost,
                L("JobPost"),
                url: "Mpa/JobPostManage",
                icon: "icon-grid",
                                  requiredPermissionName: JobPostAppPermissions.JobPost
                                     );

            var personInfo = new MenuItemDefinition(
                PersonInfoAppPermissions.PersonInfo,
                L("PersonInfo"),
                url: "Mpa/PersonInfoManage",
                icon: "icon-grid",
                                  requiredPermissionName: PersonInfoAppPermissions.PersonInfo
                                     );
            var approval = new MenuItemDefinition(
         ApprovalAppPermissions.Approval,
        L("Approval"),
        "icon-star",
        url: "Mpa/ApprovalManage",
                         requiredPermissionName: ApprovalAppPermissions.Approval);

             
            //……………………………………………………………………………………………………………………



            menu
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Tenants,
                    L("Tenants"),
                    url: "Mpa/Tenants",
                    icon: "icon-globe",
                    requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ) 
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Editions,
                    L("Editions"),
                    url: "Mpa/Editions",
                    icon: "icon-grid",
                    requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("Dashboard"),
                    url: "Mpa/Dashboard",
                    icon: "icon-home",
                    requiredPermissionName: CompanyAppPermissions.Company
                    )
                ).AddItem(approval)
                .AddItem(company)
                .AddItem(new MenuItemDefinition(
                PersonInfoAppPermissions.PersonInfo,
                L("CompanyInfo"),
                url: "Mpa/CompanyManage/CompanyInfo",
                icon: "icon-grid",
                                  requiredPermissionName: CompanyAppPermissions.Company_EditCompany
                                     ))
                .AddItem(jobPost)
                .AddItem(personInfo)
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Common.Administration,
                    L("Administration"),
                    icon: "icon-wrench"
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.OrganizationUnits,
                        L("OrganizationUnits"),
                        url: "Mpa/OrganizationUnits",
                        icon: "icon-layers",
                        requiredPermissionName: AppPermissions.Pages_Administration_OrganizationUnits
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Roles,
                        L("Roles"),
                        url: "Mpa/Roles",
                        icon: "icon-briefcase",
                        requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Users,
                        L("Users"),
                        url: "Mpa/Users",
                        icon: "icon-users",
                        requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.Languages,
                        L("Languages"),
                        url: "Mpa/Languages",
                        icon: "icon-flag",
                        requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Common.AuditLogs,
                        L("AuditLogs"),
                        url: "Mpa/AuditLogs",
                        icon: "icon-lock",
                        requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Maintenance,
                        L("Maintenance"),
                        url: "Mpa/Maintenance",
                        icon: "icon-wrench",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Maintenance
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        PageNames.App.Host.Settings,
                        L("Settings"),
                        url: "Mpa/HostSettings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    ).AddItem(new MenuItemDefinition(
                        PageNames.App.Tenant.Settings,
                        L("Settings"),
                        url: "Mpa/Settings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EmploeeConsts.LocalizationSourceName);
        }
    }
}