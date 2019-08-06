using Abp.AutoMapper;
using Emploee.Emploees.Companies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emploee.Web.Areas.Mpa.Models.CompanyManage
{
    public class ImportCompanyManages: CompanyEditDto
    {
        public ImportCompanyManages(CompanyEditDto output)
        {
            output.MapTo(this);
        }
    }
}