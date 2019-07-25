                            
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using Emploee.Emploees.Companies;
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
// Copyright © YoYoCms@China.2019-07-24T16:21:01. All Rights Reserved.
//<生成时间>2019-07-24T16:21:01</生成时间>
	#endregion
namespace Emploee.Emploees.Companies.Dtos
{
    /// <summary>
    /// 企业信息新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateCompanyInput  
    {
    /// <summary>
    /// 企业信息编辑Dto
    /// </summary>
		public CompanyEditDto  CompanyEditDto {get;set;}
 
    }
}
