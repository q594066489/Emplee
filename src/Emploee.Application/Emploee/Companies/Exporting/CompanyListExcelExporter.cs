


using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Emploee.DataExporting.Excel.EpPlus;
using Emploee.Dto;
using Emploee.Emploees.Companies.Authorization;
using Emploee.Emploees.Companies.Dtos;
#region 代码生成器相关信息_ABP Code Generator Info
//你好，我是ABP代码生成器的作者,欢迎您使用该工具，目前接受付费定制该工具，有需要的可以联系我
//我的邮箱:werltm@hotmail.com
// 官方网站:"http://www.yoyocms.com"
// 交流QQ群：104390185  
//微信公众号：角落的白板报
// 演示地址:"vue版本：http://vue.yoyocms.com angularJs版本:ng1.yoyocms.com"
//博客地址：http://www.cnblogs.com/wer-ltm/
//代码生成器帮助文档：http://www.cnblogs.com/wer-ltm/p/5777190.html
// <Author-作者>梁桐铭 ,微软MVP</Author-作者>
// Copyright © YoYoCms@China.2019-07-24T16:21:22. All Rights Reserved.
//<生成时间>2019-07-24T16:21:22</生成时间>
#endregion
namespace Emploee.Emploees.Companies
{
    /// <summary>
    /// 企业信息的导出EXCEL功能的实现
    /// </summary>
    public class CompanyListExcelExporter : EpPlusExcelExporterBase, ICompanyListExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public CompanyListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }



        /// <summary>
        /// 导出企业信息到EXCEL文件
        /// <param name="companyListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportCompanyToFile(List<CompanyListDto> companyListDtos)
        {


            var file = CreateExcelPackage("companyList.xlsx", excelPackage =>
            {

                var sheet = excelPackage.Workbook.Worksheets.Add(L("Company"));
                sheet.OutLineApplyStyle = true;

                AddHeader(
                    sheet,
                      L("CompanyName"),
 L("CompanyEmail"),
 L("CompanyPhone"),
 L("CompanyAddress"),
 L("CompanyScale"),
 L("CompanyIntroduce"),
 L("Classify"),
 L("Finanicing"),
 L("BussinessLicense"),
 L("RegisterDate"),
 L("isDelete")
                    );
                AddObjects(sheet, 2, companyListDtos,

             _ => _.CompanyName,

             _ => _.CompanyEmail,

             _ => _.CompanyPhone,

             _ => _.CompanyAddress,

             _ => _.CompanyScale,

             _ => _.CompanyIntroduce,

             _ => _.Classify,

             _ => _.Finanicing,

             _ => _.BussinessLicense,

        _ => _timeZoneConverter.Convert(_.RegisterDate, _abpSession.TenantId, _abpSession.GetUserId()),
             _ => _.isDelete

       );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

                for (var i = 1; i <= 11; i++)
                {
                    sheet.Column(i).AutoFit();
                }

            });
            return file;

        }







    }
}
