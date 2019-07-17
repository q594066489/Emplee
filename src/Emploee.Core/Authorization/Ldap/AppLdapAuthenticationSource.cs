using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Emploee.Authorization.Users;
using Emploee.MultiTenancy;

namespace Emploee.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
