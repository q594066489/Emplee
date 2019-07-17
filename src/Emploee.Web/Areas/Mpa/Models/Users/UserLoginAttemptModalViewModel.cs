using System.Collections.Generic;
using Emploee.Authorization.Users.Dto;

namespace Emploee.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}