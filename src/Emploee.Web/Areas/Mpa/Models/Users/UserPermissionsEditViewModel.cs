using Abp.AutoMapper;
using Emploee.Authorization.Users;
using Emploee.Authorization.Users.Dto;
using Emploee.Web.Areas.Mpa.Models.Common;

namespace Emploee.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}