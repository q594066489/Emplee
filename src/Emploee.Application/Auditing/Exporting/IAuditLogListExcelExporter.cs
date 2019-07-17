using System.Collections.Generic;
using Emploee.Auditing.Dto;
using Emploee.Dto;

namespace Emploee.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
