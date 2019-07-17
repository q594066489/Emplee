using Abp.Authorization;
using Emploee.Authorization.Roles;
using Emploee.Authorization.Users;
using Emploee.MultiTenancy;

namespace Emploee.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
