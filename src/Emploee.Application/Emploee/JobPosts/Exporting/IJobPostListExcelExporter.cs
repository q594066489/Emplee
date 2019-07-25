﻿                           
 
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Emploee.Dto;
using Emploee.Emploee.JobPosts.Dtos;
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
// Copyright © YoYoCms@China.2019-07-24T17:49:54. All Rights Reserved.
//<生成时间>2019-07-24T17:49:54</生成时间>
	#endregion
namespace Emploee.Emploee.JobPosts
{
	/// <summary>
    /// 职位发布的数据导出功能 
    /// </summary>
    public interface IJobPostListExcelExporter
    {
        
//## 可以将下面的这个实体类，作为filedto来进行接收 


    //public class FileDto
    //{
    //    [Required]
    //    public string FileName { get; set; }

    //    [Required]
    //    public string FileType { get; set; }

    //    [Required]
    //    public string FileToken { get; set; }

    //    public FileDto()
    //    {
            
    //    }

    //    public FileDto(string fileName, string fileType)
    //    {
    //        FileName = fileName;
    //        FileType = fileType;
    //        FileToken = Guid.NewGuid().ToString("N");
    //    }
    //}

        /// <summary>
        /// 导出职位发布到EXCEL文件
        /// <param name="jobPostListDtos">导出信息的DTO</param>
        /// </summary>
        FileDto ExportJobPostToFile(List<JobPostListDto> jobPostListDtos);



    }
}
