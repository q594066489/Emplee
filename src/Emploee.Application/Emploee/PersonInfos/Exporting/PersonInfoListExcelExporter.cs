


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
using Emploee.Emploee.PersonInfos.Authorization;
using Emploee.Emploee.PersonInfos.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T22:15:07. All Rights Reserved.
//<生成时间>2019-07-24T22:15:07</生成时间>
#endregion
namespace Emploee.Emploee.PersonInfos
{
    /// <summary>
    /// 个人中心的导出EXCEL功能的实现
    /// </summary>
    public class PersonInfoListExcelExporter : EpPlusExcelExporterBase, IPersonInfoListExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public PersonInfoListExcelExporter(ITimeZoneConverter timeZoneConverter, IAbpSession abpSession)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }



        /// <summary>
        /// 导出个人中心到EXCEL文件
        /// <param name="personInfoListDtos">导出信息的DTO</param>
        /// </summary>
        public FileDto ExportPersonInfoToFile(List<PersonInfoListDto> personInfoListDtos)
        {


            var file = CreateExcelPackage("personInfoList.xlsx", excelPackage =>
            {

                var sheet = excelPackage.Workbook.Worksheets.Add(L("PersonInfo"));
                sheet.OutLineApplyStyle = true;

                AddHeader(
                    sheet,
                      L("Name"),
 L("Age"),
 L("Sex"),
 L("Education"),
 L("Phone"),
 L("Email"),
 L("ExpectPosition"),
 L("ExpectTrade"),
 L("Resume"),
 L("isOnJob"),
 L("State"),
 L("JobYear"),
 L("CreationTime")
                    );
                AddObjects(sheet, 2, personInfoListDtos,

             _ => _.Name,

             _ => _.Age,

             _ => _.Sex,

             _ => _.Education,

             _ => _.Phone,

             _ => _.Email,

             _ => _.ExpectPosition,

             _ => _.ExpectTrade,

             _ => _.Resume,

             _ => _.isOnJob,

             _ => _.State,

             _ => _.JobYear,

        _ => _timeZoneConverter.Convert(_.CreationTime, _abpSession.TenantId, _abpSession.GetUserId())
       );
                //写个时间转换的吧
                //var creationTimeColumn = sheet.Column(10);
                //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

                for (var i = 1; i <= 13; i++)
                {
                    sheet.Column(i).AutoFit();
                }

            });
            return file;

        }







    }
}
