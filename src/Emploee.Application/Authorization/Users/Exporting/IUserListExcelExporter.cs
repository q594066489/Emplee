using System.Collections.Generic;
using Emploee.Authorization.Users.Dto;
using Emploee.Dto;

namespace Emploee.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}