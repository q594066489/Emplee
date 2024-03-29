﻿                                                                                                   

         
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
using Emploee.Emploee.JobUrgents.Authorization;
    using Emploee.Emploee.JobUrgents.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T21:24:13. All Rights Reserved.
//<生成时间>2019-07-24T21:24:13</生成时间>
	#endregion
    namespace Emploee.Emploee.JobUrgents
{
    /// <summary>
    /// 职位加急的导出EXCEL功能的实现
    /// </summary>
    public class JobUrgentListExcelExporter : EpPlusExcelExporterBase, IJobUrgentListExcelExporter
    {
     
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;


        /// <summary>
        /// 构造方法
        /// </summary>
        public JobUrgentListExcelExporter(ITimeZoneConverter timeZoneConverter,     IAbpSession abpSession)
        {
                       _timeZoneConverter = timeZoneConverter;    
                     _abpSession = abpSession;
        }

    

         /// <summary>
        /// 导出职位加急到EXCEL文件
        /// <param name="jobUrgentListDtos">导出信息的DTO</param>
        /// </summary>
    public    FileDto ExportJobUrgentToFile(List<JobUrgentListDto> jobUrgentListDtos){


var file=CreateExcelPackage("jobUrgentList.xlsx",excelPackage=>{

var sheet=excelPackage.Workbook.Worksheets.Add(L("JobUrgent"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                          L("JobId"),  
     L("Weight"),  
     L("UrgentType"),  
     L("UrgentDate"),  
     L("UrgentLength"),  
     L("isDelete"),  
     L("CreationTime")  
                        );
         AddObjects(sheet,2,jobUrgentListDtos,
            
      _ => _.JobId,   
       
      _ => _.Weight,   
       
      _ => _.UrgentType,   
       
 _ =>_timeZoneConverter.Convert( _.UrgentDate,_abpSession.TenantId, _abpSession.GetUserId()),          
      _ => _.UrgentLength,   
       
      _ => _.isDelete,   
       
 _ =>_timeZoneConverter.Convert( _.CreationTime,_abpSession.TenantId, _abpSession.GetUserId())   
);
                    //写个时间转换的吧
          //var creationTimeColumn = sheet.Column(10);
                    //creationTimeColumn.Style.Numberformat.Format = "yyyy-mm-dd";

        for (var i = 1; i <= 7; i++)
                    {
                        sheet.Column(i).AutoFit();
                    }       

});
   return file;

}


 

 
  

    }
    }
